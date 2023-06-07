Public Class FormUsuario

    Private dUsuario As New UsuarioDao
    Dim usuario As New UsuarioEntidad

    'QUE SE LLENEN LOS CAMPOS CUANDO SE SELECCIONEN'



    Sub MostrarRegistros()
        Try
            DGVusuario.DataSource = dUsuario.MostrarRegistros().Tables(0)
            DGVusuario.Refresh()
            GroupBox1.Text = "Registros Guardados: " & DGVusuario.Rows.Count
        Catch ex As Exception

        End Try
    End Sub
    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click

        Try
            Dim usuario As New UsuarioEntidad
            usuario.NombreUsuario = TxtNombre.Text
            usuario.ClaveUsuario = TxtClave.Text

            If dUsuario.GuardarRegistro(usuario) Then
                MsgBox("Registro guardado satisfactoriamente.", MsgBoxStyle.Information, "Clinica")
            Else
                MsgBox("No se pudo guardar el registro...", MsgBoxStyle.Exclamation, "Clinica")
            End If

        Catch ex As Exception
            MsgBox("Error al guardar registro: " & ex.Message, MsgBoxStyle.Critical, "Clinica")

        End Try


        MostrarRegistros()

    End Sub

    Private Sub FormUsuario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MostrarRegistros()
    End Sub

    Private Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles BtnEliminar.Click
        Try
            Dim selectedRow As DataGridViewRow = DGVusuario.SelectedRows(0)
            Dim usuarioID As Integer = CInt(selectedRow.Cells("usuarioID").Value)

            If dUsuario.EliminarRegistro(usuarioID) Then
                MsgBox("Registro eliminado satisfactoriamente.", MsgBoxStyle.Information, "Clinica")
            Else
                MsgBox("No se pudo eliminar el registro.", MsgBoxStyle.Exclamation, "Clinica")
            End If
        Catch ex As Exception
            MsgBox("Error al eliminar el registro: " & ex.Message, MsgBoxStyle.Critical, "Clinica")
        End Try

        MostrarRegistros()
    End Sub

    Private Sub BtnEditar_Click(sender As Object, e As EventArgs) Handles BtnEditar.Click

        If DGVusuario.SelectedRows.Count > 0 Then
            Dim usuarioID As Integer = CInt(DGVusuario.SelectedRows(0).Cells("usuarioID").Value)

            Dim usuario As New UsuarioEntidad()
            usuario.UsuarioID = usuarioID
            usuario.NombreUsuario = TxtNombre.Text
            usuario.ClaveUsuario = TxtClave.Text

            Try
                Dim resp = dUsuario.EditarRegistro(usuario)
                If (resp) Then
                    MsgBox("Registro editado satisfactoriamente", MsgBoxStyle.Information, "Clinica")
                Else
                    MsgBox("No se pudo editar el registro.", MsgBoxStyle.Exclamation, "Clinica")
                End If
            Catch ex As Exception
                MsgBox("Error al editar el registro: " & ex.Message, MsgBoxStyle.Critical, "Clinica")
            End Try
        Else
            MsgBox("No se ha seleccionado ningún registro para editar.", MsgBoxStyle.Exclamation, "Clinica")
        End If

        MostrarRegistros()




    End Sub




    Private Sub BtnNuevo_Click(sender As Object, e As EventArgs) Handles BtnNuevo.Click

        TxtNombre.Clear()
        TxtClave.Clear()
        'BtnEditar.Enabled = False
        'BtnEliminar.Enabled = False
        'BtnGuardar.Enabled = True
        TxtNombre.Focus()
        TxtClave.Focus()

    End Sub


    Private Sub CargarDatosUsuario(usuarioID As Integer)
        Dim usuario As UsuarioEntidad = dUsuario.BuscarRegistro(usuarioID)

        If usuario IsNot Nothing Then
            TxtNombre.Text = usuario.NombreUsuario
            TxtClave.Text = usuario.ClaveUsuario
        End If
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        Dim nombreUsuario As String = TxtBuscar.Text.Trim()

        If String.IsNullOrEmpty(nombreUsuario) Then
            MostrarRegistros() ' Mostrar todos los registros si no se ingresó un nombre de usuario
        Else
            FiltrarRegistrosPorNombreUsuario(nombreUsuario)
        End If
    End Sub

    Private Sub FiltrarRegistrosPorNombreUsuario(nombreUsuario As String)
        Try
            Dim ds As DataSet = dUsuario.MostrarRegistros()
            Dim dt As DataTable = ds.Tables(0)

            ' Filtrar los registros en el DataTable según el nombre de usuario
            Dim dv As New DataView(dt)
            dv.RowFilter = $"nombreUsuario LIKE '%{nombreUsuario}%'"

            ' Mostrar los registros filtrados en el DataGridView
            DGVusuario.DataSource = dv
            DGVusuario.Refresh()

            GroupBox1.Text = "Registros Guardados: " & DGVusuario.Rows.Count
        Catch ex As Exception
            ' Manejar cualquier excepción que ocurra durante la búsqueda
            MsgBox("Error al buscar registros: " & ex.Message, MsgBoxStyle.Critical, "Clinica")
        End Try
    End Sub

    Private Sub DGVusuario_SelectionChanged(sender As Object, e As EventArgs) Handles DGVusuario.SelectionChanged
        If DGVusuario.SelectedRows.Count > 0 Then
            Dim row As DataGridViewRow = DGVusuario.SelectedRows(0)

            TxtNombre.Text = row.Cells("nombreUsuario").Value.ToString()
            TxtClave.Text = row.Cells("claveUsuario").Value.ToString()

            BtnGuardar.Enabled = False


        End If
    End Sub

    Private Sub DGVusuario_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVusuario.CellContentClick

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs)

    End Sub
End Class