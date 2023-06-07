Public Class FormPaciente
    Private dPaciente As New PacienteDao

    'Que se llenen los campos al seleciionar fila'

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click

        Try
            Dim paciente As New PacienteEntidad
            paciente.NombrePaciente = TxtNombre.Text
            paciente.ApellidoPaciente = TxtApellido.Text
            paciente.FechaRegistro = DatePaciente.Value
            paciente.Telefono = TxtTelefono.Text
            paciente.Direccion = TxtDireccion.Text
            paciente.Email = TxtEmail.Text
            paciente.Alergias = TxtAlergias.Text
            paciente.Notas = TxtNotas.Text
            paciente.Deleted = False



            If dPaciente.GuardarRegistro(paciente) Then
                MsgBox("Registro guardado satisfactoriamente.", MsgBoxStyle.Information, "Clinica")
            Else
                MsgBox("No se pudo guardar el registro...", MsgBoxStyle.Exclamation, "Clinica")
            End If

        Catch ex As Exception
            MsgBox("Error al guardar registro: " & ex.Message, MsgBoxStyle.Critical, "Clinica")

        End Try


        MostrarRegistros()



    End Sub

    Sub MostrarRegistros()
        Try
            DGVpaciente.DataSource = dPaciente.MostrarRegistros().Tables(0)
            DGVpaciente.Refresh()
            GroupBox1.Text = "Registros Guardados: " & DGVpaciente.Rows.Count
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FormPaciente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MostrarRegistros()

    End Sub

    Private Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles BtnEliminar.Click
        Try
            Dim selectedRow As DataGridViewRow = DGVpaciente.SelectedRows(0)
            Dim pacienteID As Integer = CInt(selectedRow.Cells("pacienteID").Value)

            If dPaciente.EliminarRegistro(pacienteID) Then
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
        If DGVpaciente.SelectedRows.Count > 0 Then
            Dim pacienteID As Integer = CInt(DGVpaciente.SelectedRows(0).Cells("pacienteID").Value)

            Dim paciente As New PacienteEntidad()
            paciente.PacienteID = pacienteID
            paciente.NombrePaciente = TxtNombre.Text
            paciente.ApellidoPaciente = TxtApellido.Text
            paciente.FechaRegistro = DatePaciente.Value
            paciente.Telefono = TxtTelefono.Text
            paciente.Direccion = TxtDireccion.Text
            paciente.Email = TxtEmail.Text
            paciente.Alergias = TxtAlergias.Text
            paciente.Notas = TxtNotas.Text
            paciente.Deleted = False


            Try
                Dim resp = dPaciente.EditarRegistro(paciente)
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
        TxtApellido.Clear()
        DatePaciente.Value = DateTime.Now
        TxtTelefono.Clear()
        TxtDireccion.Clear()
        TxtEmail.Clear()
        TxtAlergias.Clear()
        TxtNotas.Clear()

        'BtnEditar.Enabled = False
        'BtnEliminar.Enabled = False
        'BtnGuardar.Enabled = True

        TxtNombre.Focus()
        TxtApellido.Focus()
        DatePaciente.Select()
        TxtTelefono.Focus()
        TxtDireccion.Focus()
        TxtEmail.Focus()
        TxtAlergias.Focus()
        TxtNotas.Focus()
    End Sub

    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click

        Dim nombrePaciente As String = TxtBuscar.Text.Trim()

        If String.IsNullOrEmpty(nombrePaciente) Then
            MostrarRegistros() ' Mostrar todos los registros si no se ingresó un nombre de usuario
        Else
            FiltrarRegistrosPorNombrePaciente(nombrePaciente)
        End If
    End Sub

    Private Sub FiltrarRegistrosPorNombrePaciente(nombrePaciente As String)
        Try
            Dim ds As DataSet = dPaciente.MostrarRegistros()
            Dim dt As DataTable = ds.Tables(0)

            ' Filtrar los registros en el DataTable según el nombre de usuario
            Dim dv As New DataView(dt)
            dv.RowFilter = $"nombrePaciente LIKE '%{nombrePaciente}%'"

            ' Mostrar los registros filtrados en el DataGridView
            DGVpaciente.DataSource = dv
            DGVpaciente.Refresh()

            GroupBox1.Text = "Registros Guardados: " & DGVpaciente.Rows.Count
        Catch ex As Exception
            ' Manejar cualquier excepción que ocurra durante la búsqueda
            MsgBox("Error al buscar registros: " & ex.Message, MsgBoxStyle.Critical, "Clinica")
        End Try
    End Sub

    Private Sub DGVpaciente_SelectionChanged(sender As Object, e As EventArgs) Handles DGVpaciente.SelectionChanged

        If DGVpaciente.SelectedRows.Count > 0 Then
            Dim row As DataGridViewRow = DGVpaciente.SelectedRows(0)

            TxtNombre.Text = row.Cells("nombrePaciente").Value.ToString()
            TxtApellido.Text = row.Cells("apellidoPaciente").Value.ToString()

            If TypeOf row.Cells("fechaRegistro").Value Is DateTime Then
                Dim fechaRegistro As DateTime = DirectCast(row.Cells("fechaRegistro").Value, DateTime)
                DatePaciente.Value = fechaRegistro ' Assign the DateTime value to the DateTimePicker control
            End If

            TxtTelefono.Text = row.Cells("telefono").Value.ToString()
            TxtDireccion.Text = row.Cells("direccion").Value.ToString()
            TxtEmail.Text = row.Cells("email").Value.ToString()
            TxtAlergias.Text = row.Cells("alergias").Value.ToString()
            TxtNotas.Text = row.Cells("notas").Value.ToString()

            BtnGuardar.Enabled = False
        End If

    End Sub

    Private Sub DGVpaciente_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVpaciente.CellContentClick

    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PanelTitleBar_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub
End Class