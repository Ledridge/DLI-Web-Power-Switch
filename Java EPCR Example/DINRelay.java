/*
 * DINRelay.java
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>
 */
package com.dreamlinx.automation;

import java.io.IOException;
import java.io.InputStream;
import java.net.MalformedURLException;
import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

import org.apache.commons.httpclient.HttpClient;
import org.apache.commons.httpclient.HttpException;
import org.apache.commons.httpclient.cookie.CookiePolicy;
import org.apache.commons.httpclient.methods.GetMethod;
import org.apache.commons.httpclient.methods.PostMethod;


/**
 * @author Mark Shurgot
 *
 */
public class DINRelay {

    /**
     * update this to your UserUtil.pl script location if you plan on 
     * invoking perl rather than using the http method
     */
    private static final String DEFAULT_SCRIPT_LOCATION =
        "/Users/mshurgot/UserUtil.pl";
    private static final String DEFAULT_IP_ADDRESS = "192.168.0.100";
    private static final String DEFAULT_USERNAME = "admin";
    private static final String DEFAULT_PASSWORD = "1234";

    private String ipAddress = DEFAULT_IP_ADDRESS;
    private String username = DEFAULT_USERNAME;
    private String password = DEFAULT_PASSWORD;
    private String scriptLocation = DEFAULT_SCRIPT_LOCATION;

    // using http is defaulted to true
    private boolean useHttp = true;
    private boolean debugOn = false;
    private HttpClient httpClient = null;
    
    /**
     * @return the ipAddress
     */
    public String getIpAddress() {
        return ipAddress;
    }
    
    /**
     * @param ipAddress the ipAddress to set
     */
    public void setIpAddress(String ipAddress) {
        this.ipAddress = ipAddress;
    }
    
    /**
     * @return the username
     */
    public String getUsername() {
        return username;
    }
    
    /**
     * @param username the username to set
     */
    public void setUsername(String username) {
        this.username = username;
    }
    
    /**
     * @return the password
     */
    public String getPassword() {
        return password;
    }
    
    /**
     * @param password the password to set
     */
    public void setPassword(String password) {
        this.password = password;
    }

    
    /**
     * @return the scriptLocation
     */
    public String getScriptLocation() {
        return scriptLocation;
    }

    
    /**
     * @param scriptLocation the scriptLocation to set
     */
    public void setScriptLocation(String scriptLocation) {
        this.scriptLocation = scriptLocation;
    }

    
    /**
     * @return the useHttp
     */
    public boolean getUseHttp() {
        return useHttp;
    }

    
    /**
     * @param useHttp the useHttp to set
     */
    public void setUseHttp(boolean useHttp) {
        this.useHttp = useHttp;
    }

    
    /**
     * @return the debugOn
     */
    public boolean isDebugOn() {
        return debugOn;
    }

    
    /**
     * @param debugOn the debugOn to set
     */
    public void setDebugOn(boolean debugOn) {
        this.debugOn = debugOn;
    }

    /**
     * Turns on the relay at the given port number
     * @param port
     * @throws IOException
     */
    public void on(int port) throws IOException {
        if (debugOn) {
            System.out.println("on(" + port + ")");
        }
        if (!useHttp) {
            String[] command = {"perl", scriptLocation, ipAddress,
                                username + ":" + password,  port + "on"};
            runCommand(command);
        } else {
            sendHttpRequest(port, "ON");
        }
    }


    /**
     * Turns off the relay at the given port number
     * @param port
     * @throws IOException
     */
    public void off(int port) throws IOException {
        if (debugOn) {
            System.out.println("off(" + port + ")");
        }
        if (!useHttp) {
            String[] command = {"perl", scriptLocation, ipAddress,
                                username + ":" + password,  port + "off"};
            runCommand(command);
        } else {
            sendHttpRequest(port, "OFF");
        }
    }


    /**
     * Sends a switch request to the HTTP Server on the DIN Relay.
     * @param port
     * @param onOff
     * @throws MalformedURLException
     * @throws HttpException
     * @throws IOException
     */
    private void sendHttpRequest(int port, String onOff)
            throws MalformedURLException, IOException, HttpException {
        if (httpClient == null) {
            setupHttpClient();
        }

        GetMethod getMethod = new GetMethod("http://" + ipAddress
                                            + "/outlet?" + port + "=" + onOff);
        try {
            int result = httpClient.executeMethod(getMethod);
            if (result != 200) {
                throw new HttpException(result + " - "
                                        + getMethod.getStatusText());
            }
        } finally {
            getMethod.releaseConnection();
        }
    }


    /**
     * Creates an HttpClient to communicate with the DIN relay.
     * @throws MalformedURLException
     * @throws HttpException
     * @throws IOException
     */
    private void setupHttpClient() throws MalformedURLException,
                                                    HttpException, IOException {
        httpClient = new HttpClient();
        httpClient.getParams().setCookiePolicy(
                                           CookiePolicy.BROWSER_COMPATIBILITY);

        GetMethod getMethod = new GetMethod("http://" + ipAddress);
        int result = httpClient.executeMethod(getMethod);
        if (result != 200) {
            throw new HttpException(result + " - " + getMethod.getStatusText());
        }

        String response = getMethod.getResponseBodyAsString();
        getMethod.releaseConnection();

        String regex = "name=\"Challenge\" value=\".*\"";
        Pattern pattern = 
            Pattern.compile(regex, Pattern.CASE_INSENSITIVE);
        Matcher matcher = pattern.matcher(response);
        String challenge = "";
        while (matcher.find()) {
            int start = matcher.start(0);
            int end = matcher.end(0);
            challenge = response.substring(start + 24, end - 1);
        }

        String md5Password = challenge + username + password + challenge;
        md5Password = toMD5(md5Password);
        
        PostMethod postMethod = new PostMethod("http://" + ipAddress
                                               + "/login.tgi");
        postMethod.addParameter("Username", username);
        postMethod.addParameter("Password", md5Password);

        result = httpClient.executeMethod(postMethod);
        if (result != 200) {
            throw new HttpException(result + " - "
                                    + postMethod.getStatusText());
        }
        postMethod.releaseConnection();
    }

    /**
     * This method runs the provided command in the current runtime environment
     * within the instance of this virtual machine.
     *
     * @param commandWithArgs Command and arguments.
     * @return Process
     * @throws IOException
     */
    private void runCommand(String[] commandWithArgs)
        throws IOException {
        Process p = Runtime.getRuntime().exec(commandWithArgs);
        try {
            // read and close all streams to prevent open handles
            InputStream i = p.getInputStream();
            while(i.available() > 0) {
                i.read();
            }
            i.close();
            i = p.getErrorStream();
            while(i.available() > 0) {
                i.read();
            }
            i.close();
            p.getOutputStream().close();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    /**
     * This method returns a message digest of the given string using the
     * MD5 message digest algorithm. If the MD5 algorithm is not available in
     * the caller's environment, then the original message is returned.
     *
     * @param value Arbitrary length message to digest.
     * @return 32 character MD5 message digest of given message.
     */
     public String toMD5(String value) {
         byte axMsg[] = value.getBytes();

         try {
             MessageDigest md5 = MessageDigest.getInstance("MD5");
             byte axMD5[] = md5.digest(axMsg);

             StringBuffer sbMD5 = new StringBuffer(axMD5.length * 2);
             for (int iByteIdx = 0; iByteIdx < axMD5.length; iByteIdx++) {
                 String hexByte = "0" + Integer.toHexString(
                     new Byte(axMD5[iByteIdx]).intValue());
                 sbMD5.append(hexByte.substring(hexByte.length() - 2));
             }

             return sbMD5.toString().toLowerCase();
         }
         catch (NoSuchAlgorithmException e) {
             e.printStackTrace();
             return value;
         }
     }
}
