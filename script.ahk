SetKeyDelay, 0, 0
#SingleInstance force
SetTitleMatchMode, 2

#IfWinActive, ahk_exe PotPlayerMini64.exe
R::
Send 12
Sleep 250
Send 12
Send #1
Sleep 250
Send {F5}
return

#IfWinActive, ahk_exe PotPlayerMini64.exe
LShift & LButton::
Send {LButton}
Send {LShift up}
Send #1
Sleep 250
Send {F3}
Sleep 250
Send {F4}
return

#IfWinActive, ahk_exe WpfApp2.exe
^Enter::
Send {F6}
return