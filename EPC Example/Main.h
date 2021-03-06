//---------------------------------------------------------------------------

#ifndef MainH
#define MainH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <IdBaseComponent.hpp>
#include <IdComponent.hpp>
#include <IdTCPClient.hpp>
#include <IdTCPConnection.hpp>
#include <IdHTTP.hpp>
#include <IdAntiFreeze.hpp>
#include <IdAntiFreezeBase.hpp>
#include <ComCtrls.hpp>
#include <Buttons.hpp>


#define CM_APPSTART WM_USER+68521

//---------------------------------------------------------------------------
class TForm1 : public TForm
{
__published:	// IDE-managed Components
	TIdHTTP *IdHTTP;
	TButton *BtnGetStatus;
	TEdit *EdtURL;
	TEdit *EdtPassword;
	TIdAntiFreeze *IdAntiFreeze1;
	TLabel *LabelIP;
	TLabel *LabelPassword;
	TLabel *LabelHeading;
	TEdit *EdtPort;
	TLabel *LabelPort;
	TLabel *Label1;
	TLabel *Label2;
	TLabel *Label3;
	TLabel *Label4;
	TLabel *Label5;
	TLabel *Label6;
	TLabel *Label7;
	TLabel *Label8;
	TSpeedButton *SwitchButton1;
	TSpeedButton *SwitchButton2;
	TSpeedButton *SwitchButton3;
	TSpeedButton *SwitchButton4;
	TSpeedButton *SwitchButton5;
	TSpeedButton *SwitchButton6;
	TSpeedButton *SwitchButton7;
	TSpeedButton *SwitchButton8;
	TLabel *LabelHint;
	TButton *BtnExit;
	TLabel *LabelControllerName;
	TLabel *LblEpcType;
	TButton *BtnResetNames;
	TButton *BtnAllOn;
	TButton *BtnAllOff;
	TButton *BtnResetAll;
	TSpeedButton *CycleButton1;
	TSpeedButton *CycleButton2;
	TSpeedButton *CycleButton3;
	TSpeedButton *CycleButton4;
	TSpeedButton *CycleButton5;
	TSpeedButton *CycleButton6;
	TSpeedButton *CycleButton7;
	TSpeedButton *CycleButton8;
	TButton *Button1;
	TButton *Button2;
	void __fastcall BtnGetStatusClick(TObject *Sender);
	void __fastcall BtnExitClick(TObject *Sender);
	void __fastcall BtnResetNamesClick(TObject *Sender);
	void __fastcall BtnAllOnClick(TObject *Sender);
	void __fastcall BtnAllOffClick(TObject *Sender);
	void __fastcall SwitchButtonClick(TObject *Sender);
	void __fastcall BtnResetAllClick(TObject *Sender);
	void __fastcall CycleButtonClick(TObject *Sender);
	void __fastcall FormClose(TObject *Sender, TCloseAction &Action);
	void __fastcall Button1Click(TObject *Sender);
	void __fastcall Button2Click(TObject *Sender);
private:	// User declarations
	void __fastcall SwitchButton111Click(TObject *Sender);
	void __fastcall GetStatus();
	void __fastcall ClearStatus();
	void __fastcall DisableButtons();
	void __fastcall SaveSettings();
	void __fastcall LoadSettings();
	void __fastcall UpdateStatus(const AnsiString &);
	void __fastcall AllOn();
	void __fastcall AllOff();
  void __fastcall ResetPowerRecovery();
  void __fastcall ResetLinks();
  void __fastcall ResetDelay();
  void __fastcall ResetNetwork();
  void __fastcall ResetOutletNames();
	void __fastcall UpdateCycleStatus();
	bool __fastcall SetUpHTTP();


public:		// User declarations
	__fastcall TForm1(TComponent* Owner);

	void __fastcall AppStart( TMessage &Message );
	BEGIN_MESSAGE_MAP
		VCL_MESSAGE_HANDLER(CM_APPSTART, TMessage, AppStart);
	END_MESSAGE_MAP( TForm );


};
//---------------------------------------------------------------------------
extern PACKAGE TForm1 *Form1;
//---------------------------------------------------------------------------
#endif
