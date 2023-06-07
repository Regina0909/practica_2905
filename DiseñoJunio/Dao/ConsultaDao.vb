
Imports System.Data.SqlClient


Public Class ConsultaDao

    Private strConn As String = My.Settings.StrConexion


    Public Function GuardarRegistro(ByVal consulta As ConsultaEntidad) As Boolean

        Dim flag As Boolean = False
        Try
            Dim tsql As String = "INSERT INTO Consulta(cantServicios, fechaConsulta, pacienteID, servicioID) values(@cantServicios, @fechaConsulta, @pacienteID, @servicioID)"
            Dim conn As New SqlConnection(strConn)
            Dim cmd As New SqlCommand
            cmd.CommandType = CommandType.Text
            cmd.CommandText = tsql
            cmd.Parameters.AddWithValue("@cantServicios", consulta.CantServicios)
            cmd.Parameters.AddWithValue("@fechaConsulta", consulta.FechaConsulta)
            cmd.Parameters.AddWithValue("@pacienteID", consulta.PacienteID.PacienteID)
            cmd.Parameters.AddWithValue("@servicioID", consulta.ServicioID.ServicioID)

            cmd.Connection = conn
            cmd.Connection.Open()
            If (cmd.ExecuteNonQuery <> 0) Then
                flag = True
            End If
            cmd.Connection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            flag = False
        End Try
        Return flag








    End Function

    Public Function MostrarRegistros() As DataSet 'EDITAR'

        Dim ds As New DataSet
        Try
            Dim tsql As String = "SELECT Consulta.consultaID, Consulta.cantServicios, Consulta.fechaConsulta, Consulta.pacienteID, Consulta.servicioID, Servicio.nombreServicio as 'nomServicio' FROM Consulta INNER JOIN Servicio ON Consulta.servicioID = Servicio.ServicioID"

            Dim conn As New SqlConnection(strConn)
            Dim da As New SqlDataAdapter(tsql, conn)
            da.Fill(ds)

            If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                ds.Tables(0).Columns("servicioID").ColumnName = "Servicio"
            End If
        Catch ex As Exception
        End Try
        Return ds

    End Function

    Public Function EditarRegistro(ByVal consulta As ConsultaEntidad) As Boolean

        Dim resp As Boolean = False
        Try
            Dim tsql As String = "UPDATE Consulta SET cantServicios = @cantServicios, fechaConsulta = @fechaConsulta, pacienteID = @pacienteID, servicioID = @servicioID, deleted = @deleted  WHERE consultaID = @consultaID"
            Using conn As New SqlConnection(strConn)
                Using cmd As New SqlCommand(tsql, conn)

                    cmd.Parameters.AddWithValue("@cantServicios", consulta.CantServicios)
                    cmd.Parameters.AddWithValue("@fechaConsulta", consulta.FechaConsulta)

                    cmd.Parameters.AddWithValue("@pacienteID", consulta.PacienteID.PacienteID)
                    cmd.Parameters.AddWithValue("@ServicioID", consulta.ServicioID.ServicioID)
                    cmd.Parameters.AddWithValue("@deleted", consulta.Deleted)
                    cmd.Parameters.AddWithValue("@consultaID", consulta.ConsultaID)

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

    Public Function EliminarRegistro(ByVal consultaID As Integer) As Boolean
        Dim resp As Boolean = False
        Try
            Dim tsql As String = "UPDATE Consulta SET deleted = 1 WHERE consultaID = @consultaID"
            Using conn As New SqlConnection(strConn)
                Using cmd As New SqlCommand(tsql, conn)
                    cmd.Parameters.AddWithValue("@consultaID", consultaID)
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

    Public Function BuscarRegistro(ByVal consultaID As Integer) As ConsultaEntidad
        Dim consulta As New ConsultaEntidad
        Try
            Dim tsql As String = "select * from Consulta where consultaID = @consultaID"
            Dim conn As New SqlConnection(strConn)
            Dim tbl As New DataTable
            Dim da As New SqlDataAdapter(tsql, conn)
            da.SelectCommand.Parameters.AddWithValue("@consultaID", consultaID)
            da.Fill(tbl)
            If tbl.Rows.Count > 0 Then
                consulta.ConsultaID = tbl.Rows(0).Item("consultaID")
                consulta.CantServicios = tbl.Rows(0).Item("cantServicios")
                consulta.FechaConsulta = tbl.Rows(0).Item("fechaConsulta")
                consulta.PacienteID = tbl.Rows(0).Item("PacienteID")
                consulta.servicioID = tbl.Rows(0).Item("ServicioID")
                consulta.Deleted = tbl.Rows(0).Item("deleted")

            End If
        Catch ex As Exception

        End Try
        Return consulta
    End Function

    'EDITAR'

    Public Function ListarConsulta() As DataSet
        Dim ds As New DataSet
        Try
            Dim tsql As String = "SELECT Consulta.cantServicios, CONVERT(varchar(10), Consulta.fechaConsulta, 103) as N'FechaConsulta', Consulta.pacienteID, Servicio.nombreServicio AS Servicio, INNER JOIN Servicio ON Servicio.servicioID = Consulta.servicioID,  Consulta.deleted FROM Consulta"
            Dim conn As New SqlConnection(strConn)
            Dim da As New SqlDataAdapter(tsql, conn)
            da.Fill(ds)
        Catch ex As Exception
        End Try
        Return ds
    End Function


End Class
