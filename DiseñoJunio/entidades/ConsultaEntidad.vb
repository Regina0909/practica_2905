Public Class ConsultaEntidad

    Private _consultaID As Integer
    Private _cantServicios As Integer
    Private _fechaConsulta As DateTime
    Private _pacienteID As New PacienteEntidad
    Private _servicioID As New ServicioEntidad
    Private _deleted As New Boolean




    Public Property ConsultaID As Integer
        Get
            Return _consultaID

        End Get
        Set(value As Integer)
            _consultaID = value

        End Set
    End Property

    Public Property CantServicios As Integer
        Get
            Return _cantServicios

        End Get
        Set(value As Integer)
            _cantServicios = value

        End Set
    End Property

    Public Property FechaConsulta As DateTime
        Get
            Return _fechaConsulta

        End Get
        Set(value As DateTime)
            _fechaConsulta = value

        End Set
    End Property

    Public Property PacienteID As PacienteEntidad
        Get
            Return _PacienteID

        End Get
        Set(value As PacienteEntidad)
            _PacienteID = value

        End Set
    End Property

    Public Property ServicioID As ServicioEntidad
        Get
            Return _servicioID

        End Get
        Set(value As ServicioEntidad)
            _servicioID = value

        End Set
    End Property

    Public Property Deleted As Boolean
        Get
            Return _deleted

        End Get
        Set(value As Boolean)
            _deleted = value

        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(consultaID As Integer, cantServicios As Integer, fechaConsulta As DateTime, pacienteID As PacienteEntidad, servicioID As ServicioEntidad, deleted As Boolean)
        Me.ConsultaID = consultaID
        Me.CantServicios = cantServicios
        Me.FechaConsulta = fechaConsulta
        Me.PacienteID = pacienteID
        Me.ServicioID = servicioID
        Me.Deleted = deleted
    End Sub

End Class
