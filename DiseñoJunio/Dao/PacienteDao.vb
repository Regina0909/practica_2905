
Imports System.Data.SqlClient
Public Class PacienteDao

    Private strConn As String = My.Settings.StrConexion
    Public Function GuardarRegistro(ByVal paciente As PacienteEntidad) As Boolean

        Dim resp As Boolean = False
        Try
            Dim tsql As String = "INSERT INTO Paciente(nombrePaciente, apellidoPaciente, fechaRegistro, telefono, direccion, email, alergias, notas, deleted) VALUES (@nombreP, @apellidoP, @fechaRegistro, @telefono, @direccion, @email, @alergias, @notas, @deleted)"

            Using conn As New SqlConnection(strConn)
                Using cmd As New SqlCommand(tsql, conn)

                    cmd.Parameters.AddWithValue("@nombreP", paciente.NombrePaciente)
                    cmd.Parameters.AddWithValue("@apellidoP", paciente.ApellidoPaciente)
                    cmd.Parameters.AddWithValue("@fechaRegistro", paciente.FechaRegistro)
                    cmd.Parameters.AddWithValue("@telefono", paciente.Telefono)
                    cmd.Parameters.AddWithValue("@direccion", paciente.Direccion)
                    cmd.Parameters.AddWithValue("@email", paciente.Email)
                    cmd.Parameters.AddWithValue("@alergias", paciente.Alergias)
                    cmd.Parameters.AddWithValue("@notas", paciente.Notas)
                    cmd.Parameters.AddWithValue("@deleted", paciente.Deleted)

                    conn.Open()
                    If cmd.ExecuteNonQuery() > 0 Then
                        resp = True
                    End If
                End Using
            End Using
        Catch ex As Exception
            resp = False
        End Try
        Return resp

    End Function

    Public Function EditarRegistro(ByVal paciente As PacienteEntidad) As Boolean

        Dim resp As Boolean = False
        Try
            Dim tsql As String = "UPDATE Paciente SET nombrePaciente = @nombreP, apellidoPaciente = @apellidoP, fechaRegistro = @fechaR, telefono = @telefono, direccion = @direccion, email = @email, alergias = @alergias, notas = @notas, deleted = @deleted  WHERE pacienteID = @pacienteID"
            Using conn As New SqlConnection(strConn)
                Using cmd As New SqlCommand(tsql, conn)
                    cmd.Parameters.AddWithValue("@nombreP", paciente.NombrePaciente)
                    cmd.Parameters.AddWithValue("@apellidoP", paciente.ApellidoPaciente)
                    cmd.Parameters.AddWithValue("@fechaR", paciente.FechaRegistro)
                    cmd.Parameters.AddWithValue("@telefono", paciente.Telefono)
                    cmd.Parameters.AddWithValue("@direccion", paciente.Direccion)
                    cmd.Parameters.AddWithValue("@email", paciente.Email)
                    cmd.Parameters.AddWithValue("@alergias", paciente.Alergias)
                    cmd.Parameters.AddWithValue("@notas", paciente.Notas)
                    cmd.Parameters.AddWithValue("@deleted", paciente.Deleted)

                    cmd.Parameters.AddWithValue("@pacienteID", paciente.PacienteID)

                    conn.Open()
                    If cmd.ExecuteNonQuery() > 0 Then
                        resp = True
                    End If
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Error al editar el registro: " & ex.Message, MsgBoxStyle.Critical, "Clinica")
            resp = False
        End Try
        Return resp

    End Function

    Public Function EliminarRegistro(ByVal pacienteID As Integer) As Boolean
        Dim resp As Boolean = False
        Try
            Dim tsql As String = "UPDATE Paciente SET deleted = 1 WHERE pacienteID = @pacienteID"
            Using conn As New SqlConnection(strConn)
                Using cmd As New SqlCommand(tsql, conn)
                    cmd.Parameters.AddWithValue("@pacienteID", pacienteID)
                    conn.Open()
                    If cmd.ExecuteNonQuery() > 0 Then
                        resp = True
                    End If
                End Using
            End Using
        Catch ex As Exception
            resp = False
        End Try
        Return resp
    End Function

    Public Function MostrarRegistros() As DataSet
        Dim ds As New DataSet
        Try
            Dim tsql As String = "Select * from Paciente WHERE deleted = 0"
            Dim conn As New SqlConnection(strConn)
            Dim da As New SqlDataAdapter(tsql, conn)
            da.Fill(ds)
        Catch ex As Exception
        End Try
        Return ds
    End Function

    Public Function BuscarRegistro(ByVal pacienteID As Integer) As PacienteEntidad
        Dim paciente As New PacienteEntidad
        Try
            Dim tsql As String = "select * from Paciente where pacienteID = @pacienteID"
            Dim conn As New SqlConnection(strConn)
            Dim tbl As New DataTable
            Dim da As New SqlDataAdapter(tsql, conn)
            da.SelectCommand.Parameters.AddWithValue("@pacienteID", pacienteID)
            da.Fill(tbl)
            If tbl.Rows.Count > 0 Then
                paciente.PacienteID = tbl.Rows(0).Item("pacienteID")
                paciente.NombrePaciente = tbl.Rows(0).Item("nombrePaciente")
                paciente.ApellidoPaciente = tbl.Rows(0).Item("apellidoPaciente")
                paciente.FechaRegistro = tbl.Rows(0).Item("fechaRegistro")
                paciente.Telefono = tbl.Rows(0).Item("telefono")
                paciente.Direccion = tbl.Rows(0).Item("direccion")
                paciente.Email = tbl.Rows(0).Item("email")
                paciente.Alergias = tbl.Rows(0).Item("alergias")
                paciente.Notas = tbl.Rows(0).Item("notas")
                paciente.Deleted = tbl.Rows(0).Item("deleted")

            End If
        Catch ex As Exception

        End Try
        Return paciente
    End Function

    'LISTAR PACIENTES'
    Public Function ListarPacientes() As DataSet
        Dim ds As New DataSet
        Try
            Dim tsql As String = "SELECT Paciente.nombrePaciente + ' ' + Paciente.apellidoPaciente, CONVERT(varchar(10), Paciente.fechaRegistro, 103) as FechaRegistro, Paciente.telefono, Paciente.direccion, Paciente.email, Paciente.alergias + Paciente.notas, Paciente.deleted FROM Paciente"
            Dim conn As New SqlConnection(strConn)
            Dim da As New SqlDataAdapter(tsql, conn)
            da.Fill(ds)
        Catch ex As Exception
        End Try
        Return ds
    End Function

End Class
