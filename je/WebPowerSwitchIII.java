import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;

import org.apache.http.Header;
import org.apache.http.HeaderIterator;
import org.apache.http.HttpEntity;
import org.apache.http.HttpResponse;
import org.apache.http.auth.AuthenticationException;
import org.apache.http.auth.UsernamePasswordCredentials;
import org.apache.http.client.ClientProtocolException;
import org.apache.http.client.HttpClient;
import org.apache.http.client.methods.HttpGet;
import org.apache.http.impl.auth.BasicScheme;
import org.apache.http.impl.client.DefaultHttpClient;

public class WebPowerSwitchIII 
{
	
	public static void main(String[] args) 
	{
		// Establish an HTTP client for connections
		HttpClient httpclient = new DefaultHttpClient();
		
		// Define the GET request (Turn outlet 1 on)
		HttpGet httpget = new HttpGet("http://192.168.0.100/outlet?1=ON");

		// Add authentication to the GET request
		String username = "admin";
		String password = "1234";
		try {
			UsernamePasswordCredentials credentials = new UsernamePasswordCredentials(username, password);
			BasicScheme scheme = new BasicScheme();
			Header authorizationHeader = scheme.authenticate(credentials, httpget);
			httpget.addHeader(authorizationHeader); 
		} catch (AuthenticationException e) {
			e.printStackTrace();
			return;
		}
		
		try {
			// Send the request to the WebPowerSwitch, store the response
			HttpResponse response = httpclient.execute(httpget);
			
			
			// In the simple case of turning an outlet on/off, there should be no real
			// need to look at the response, however it may provide useful information
			// for debugging, so I've left it in.
			
			
			// Examine the response status
		    System.out.println(response.getStatusLine()+"\n");
		    
		    // Print out all the headers in the response
		    System.out.println("\nRESPONSE HEADERS:");
		    HeaderIterator it = response.headerIterator();
		    while (it.hasNext()) {
		        System.out.println(it.next());
		    }
		    
		    // Get hold of the response entity
		    HttpEntity entity = response.getEntity();
		 
			// If the response does not enclose an entity, there is no need
			// to worry about connection release
			if (entity != null) 
			{
				InputStream instream = entity.getContent();
			    try {
			        BufferedReader reader = new BufferedReader(
			        		new InputStreamReader(instream));
			        
			        // do something useful with the response content
			        System.out.println("\nRESPONSE CONTENT:");
				    String str = null;
			        while ((str = reader.readLine()) != null) {
			        	System.out.println(str);
			        }
			    } catch (IOException ex) {
			        // In case of an IOException the connection will be released
			    	// back to the connection manager automatically
			        throw ex;
			    } catch (RuntimeException ex) {
			    	// In case of an unexpected exception you may want to abort
			    	// the HTTP request in order to shut down the underlying 
			    	// connection and release it back to the connection manager.
			        httpget.abort();
			        throw ex;
			    } finally {
			        // Closing the input stream will trigger connection release
			    	instream.close();
			    }
		 
			    // When HttpClient instance is no longer needed, 
			    // shut down the connection manager to ensure
			    // immediate deallocation of all system resources
			    httpclient.getConnectionManager().shutdown();        
			}
		} catch (ClientProtocolException e) {
			e.printStackTrace();
		} catch (IOException e) {
			e.printStackTrace();
		}
	}

}