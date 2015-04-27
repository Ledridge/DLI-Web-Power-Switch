//---------------------------------------------------------------------------
#include <vcl.h>
#pragma hdrstop

#include "HourGlass.h"

static int HourGlassCounter; // Nesting counter

//---------------------------------------------------------------------------
#pragma package(smart_init)

__fastcall TGeneral_RAII_HourGlass::TGeneral_RAII_HourGlass()
{
  ++HourGlassCounter;
  Screen->Cursor=crHourGlass;
}
//---------------------------------------------------------------------------
__fastcall TGeneral_RAII_HourGlass::~TGeneral_RAII_HourGlass()
{
  if( HourGlassCounter )
    --HourGlassCounter;
  if( !HourGlassCounter ) // We were the first to request the
    Screen->Cursor=crDefault; // cursor so now it is restored.
}

