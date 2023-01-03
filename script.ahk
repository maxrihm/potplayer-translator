SetKeyDelay, 0, 0
#SingleInstance force
SetTitleMatchMode, 2

#IfWinActive, ahk_exe PotPlayerMini64.exe
R::
Send 12
Sleep 300
Send 12
Sleep 50
Send #1
Sleep 300
Send {F5}
return

#IfWinActive, ahk_exe PotPlayerMini64.exe
LShift & LButton::
Send {LButton}
Send {LShift up}
Sleep 50
Send #1
Sleep 250
Send {F4}
return

#IfWinActive, ahk_exe WpfApp2.exe
^Enter::
Send {F6}
WinActivate, ahk_exe PotPlayerMini64.exe
return

#IfWinActive, ahk_exe WpfApp2.exe
1::
Send, ^c
Sleep 50
Send, {F8}
return

#IfWinActive, ahk_exe WpfApp2.exe
2::
Send, ^c
Sleep 50
Send, {F9}
return

#IfWinActive, ahk_exe WpfApp2.exe
3::
Send, ^c
Sleep 50
Send, {F10}
return

#IfWinActive, ahk_exe WpfApp2.exe
4::
Send, ^c
Sleep 50
Send, {F11}
return
