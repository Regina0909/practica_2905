Public Class FormOpciones
    Private Sub FormOpciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub BtnAbrirUsuario_Click(sender As Object, e As EventArgs) Handles BtnAbrirUsuario.Click
        'FormUsuario.Show()

        Dim form2 As New FormUsuario()
        form2.ShowDialog(Me)
    End Sub

    Private Sub BtnAbrirServicios_Click(sender As Object, e As EventArgs) Handles BtnAbrirServicios.Click
        Dim form3 As New FormServicios()
        form3.ShowDialog(Me)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim form3 As New FormPaciente()
        form3.ShowDialog(Me)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim form4 As New FormConsulta()
        form4.ShowDialog(Me)

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Dim form5 As New FormOpcReporte()
        form5.ShowDialog(Me)




    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        Dim form5 As New FormRegFactura()
        form5.ShowDialog(Me)

    End Sub
End Class