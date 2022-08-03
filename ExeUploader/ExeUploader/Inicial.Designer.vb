<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Inicial
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Inicial))
        Me.txtRutaServer = New System.Windows.Forms.TextBox()
        Me.txtRutaLocal = New System.Windows.Forms.TextBox()
        Me.txtVersionLocal = New System.Windows.Forms.TextBox()
        Me.txtVersionServer = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'txtRutaServer
        '
        Me.txtRutaServer.Location = New System.Drawing.Point(37, 12)
        Me.txtRutaServer.Name = "txtRutaServer"
        Me.txtRutaServer.Size = New System.Drawing.Size(341, 20)
        Me.txtRutaServer.TabIndex = 0
        '
        'txtRutaLocal
        '
        Me.txtRutaLocal.Location = New System.Drawing.Point(37, 38)
        Me.txtRutaLocal.Name = "txtRutaLocal"
        Me.txtRutaLocal.Size = New System.Drawing.Size(341, 20)
        Me.txtRutaLocal.TabIndex = 1
        '
        'txtVersionLocal
        '
        Me.txtVersionLocal.Location = New System.Drawing.Point(433, 38)
        Me.txtVersionLocal.Name = "txtVersionLocal"
        Me.txtVersionLocal.Size = New System.Drawing.Size(209, 20)
        Me.txtVersionLocal.TabIndex = 2
        '
        'txtVersionServer
        '
        Me.txtVersionServer.Location = New System.Drawing.Point(433, 12)
        Me.txtVersionServer.Name = "txtVersionServer"
        Me.txtVersionServer.Size = New System.Drawing.Size(209, 20)
        Me.txtVersionServer.TabIndex = 3
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(665, 76)
        Me.Controls.Add(Me.txtVersionServer)
        Me.Controls.Add(Me.txtVersionLocal)
        Me.Controls.Add(Me.txtRutaLocal)
        Me.Controls.Add(Me.txtRutaServer)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtRutaServer As System.Windows.Forms.TextBox
    Friend WithEvents txtRutaLocal As System.Windows.Forms.TextBox
    Friend WithEvents txtVersionLocal As System.Windows.Forms.TextBox
    Friend WithEvents txtVersionServer As System.Windows.Forms.TextBox

End Class
