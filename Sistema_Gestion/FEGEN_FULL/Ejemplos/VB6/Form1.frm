VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "Form1"
   ClientHeight    =   4920
   ClientLeft      =   2385
   ClientTop       =   2985
   ClientWidth     =   7950
   LinkTopic       =   "Form1"
   ScaleHeight     =   4920
   ScaleWidth      =   7950
   Begin VB.ComboBox Combo1 
      Height          =   315
      ItemData        =   "Form1.frx":0000
      Left            =   5640
      List            =   "Form1.frx":0025
      TabIndex        =   9
      Text            =   "PDF"
      Top             =   2640
      Width           =   2055
   End
   Begin VB.CommandButton Command1 
      Caption         =   "Ejecutar"
      Height          =   495
      Left            =   360
      TabIndex        =   7
      Top             =   3960
      Width           =   1575
   End
   Begin VB.OptionButton Option1 
      Caption         =   "Envio Mail"
      Height          =   375
      Index           =   2
      Left            =   240
      TabIndex        =   6
      Top             =   3000
      Width           =   2175
   End
   Begin VB.OptionButton Option1 
      Caption         =   "Generación"
      Height          =   255
      Index           =   1
      Left            =   240
      TabIndex        =   5
      Top             =   2640
      Width           =   2175
   End
   Begin VB.OptionButton Option1 
      Caption         =   "Diseño"
      Height          =   255
      Index           =   0
      Left            =   240
      TabIndex        =   4
      Top             =   2280
      Value           =   -1  'True
      Width           =   2175
   End
   Begin VB.TextBox Text2 
      Height          =   405
      Left            =   1800
      TabIndex        =   3
      Text            =   "factura"
      ToolTipText     =   "Archivo en el cual saldra generado el comprobante"
      Top             =   960
      Width           =   3255
   End
   Begin VB.TextBox Text1 
      Height          =   405
      Left            =   1800
      TabIndex        =   2
      Text            =   "template.rtm"
      ToolTipText     =   "Archivo template que tiene el diseño de impresión"
      Top             =   480
      Width           =   3255
   End
   Begin VB.Label Label3 
      Caption         =   "Formato de generación:"
      Height          =   255
      Left            =   3240
      TabIndex        =   8
      Top             =   2640
      Width           =   1935
   End
   Begin VB.Label Label2 
      Caption         =   "Archivo de Salida:"
      Height          =   255
      Left            =   240
      TabIndex        =   1
      Top             =   960
      Width           =   1455
   End
   Begin VB.Label Label1 
      Caption         =   "Template:"
      Height          =   255
      Left            =   240
      TabIndex        =   0
      Top             =   480
      Width           =   735
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim pdfmgr
Dim template
Dim salida


Private Sub generar()
' GENERACION DE LOS DATOS
'--------------------------------------------------------------------------

Set pdfmgr = CreateObject("fegen.fegenerador")
template = App.Path + "\" + Text1.Text
salida = App.Path + "\" + Text2.Text

'Datos Vendedor

CUIT = "20-93980259-3"
RazonSocial = "BIT INGENIERIA"
Direccion = "Blanco Encalada 1204 Capital"
Telefono = "(54)-1135289656"
IngresosBrutos = "20-93980259-3"
Info1 = ""
Info2 = ""
Info3 = ""
Info4 = ""
info5 = ""
pdfmgr.SeteaDatosvendedor CUIT, RazonSocial, Direccion, Telefono, IngresosBrutos, Info1, Info2, Info3, Info4, info5

'Cabecera Comprobante

TipoComp = 1
PtoVta = 101
Nro = 30
FechaComp = "20110425"
RazonSocial = "Cliente S.A."
TipoDoc = 80
Documento = "20-11111111-3"
CondIVA = "Resp. Inscripto"
CAE = "12345678901234"
Vencimiento = "20110505"
Direccion = "Calle 100 Nro 1033"
Total = 242
Info1 = ""
Info2 = ""
Info3 = ""
Info4 = ""
info5 = ""
pdfmgr.SeteaCabecera TipoComp, PtoVta, Nro, FechaComp, RazonSocial, TipoDoc, Documento, CondIVA, CAE, Vencimiento, Direccion, Total, Info1, Info2, Info3, Info4, info5
'Cabecera Comprobante

CodigoArt = "0012333005998"
DescripcionArt = "REMERA INDIAN AZUL"
Cantidad = 3
Precio = 100#
IVA = 21
SubTotal = 100
Info1 = ""
Info2 = ""
Info3 = ""
Info4 = ""
info5 = ""
pdfmgr.InsertaDetalle CodigoArt, DescripcionArt, Cantidad, Precio, IVA, SubTotal, Info1, Info2, Info3, Info4, info5, 0, 0, 0, 0, 0

CodigoArt = "0015303005976"
DescripcionArt = "PANTALON INDIAN AZUL"
Cantidad = 1
Precio = 100
IVA = 21
SubTotal = 121
pdfmgr.InsertaDetalle CodigoArt, DescripcionArt, Cantidad, Precio, IVA, SubTotal, Info1, Info2, Info3, Info4, info5, 0, 0, 0, 0, 0

' FIN DE LA GENERACION
'-----------------------------------------------------------------------------------------

End Sub

Private Sub Command1_Click()
generar
If Option1.Item(0).Value Then
  pdfmgr.Editar template
End If
If Option1.Item(1).Value Then
  pdfmgr.generar salida + "." + Combo1.Text, template, Combo1.Text
End If
If Option1.Item(2).Value Then
  pdfmgr.EnviarPorMail template, "electrocompay@hotmail.com"
End If
End Sub

