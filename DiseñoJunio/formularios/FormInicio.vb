Public Class FormInicio

    Private usuarioDao As New UsuarioDao()
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub FormInicio_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextClave.TextChanged

    End Sub

    Private Sub BtnIngresar_Click(sender As Object, e As EventArgs) Handles BtnIngresar.Click

        Dim usuario As String = TextNombre.Text.Trim()
        Dim contraseña As String = TextClave.Text.Trim()

        Dim usuarioDao As New UsuarioDao()
        If usuarioDao.VerificarCredenciales(usuario, contraseña) Then
            ' Credenciales válidas, realizar las acciones necesarias
            MessageBox.Show("Inicio de sesión exitoso")
            FormOpciones.Show()
            ' Otro código a ejecutar después del inicio de sesión exitoso
        Else
            ' Credenciales incorrectas, mostrar un mensaje de error
            MessageBox.Show("Credenciales incorrectas")
        End If


    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Me.Hide()

    End Sub
End Class