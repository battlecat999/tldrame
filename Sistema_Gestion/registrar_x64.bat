copy "C:\Sistema_Gestion\comdlg32.dll" "C:\Windows\SysWOW64\*.*"
copy "C:\Sistema_Gestion\comdlg32.ocx" "C:\Windows\SysWOW64\*.*"

regsvr32 C:\windows\SysWOW64\comdlg32.dll
regsvr32 C:\windows\SysWOW64\comdlg32.ocx