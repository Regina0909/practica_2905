Public Class PacienteEntidad


    Private _pacienteID As Integer
    Private _nombrePaciente As String
    Private _apellidoPaciente As String
    Private _fechaRegistro As DateTime
    Private _telefono As String
    Private _direccion As String
    Private _email As String
    Private _alergias As String
    Private _notas As String
    Private _deleted As Boolean

    Public Property PacienteID As Integer
        Get
            Return _pacienteID

        End Get
        Set(value As Integer)
            _pacienteID = value

        End Set
    End Property

    Public Property NombrePaciente As String
        Get
            Return _nombrePaciente

        End Get
        Set(value As String)
            _nombrePaciente = value

        End Set
    End Property

    Public Property ApellidoPaciente As String
        Get
            Return _apellidoPaciente

        End Get
        Set(value As String)
            _apellidoPaciente = value

        End Set
    End Property

    Public Property FechaRegistro As DateTime
        Get
            Return _fechaRegistro

        End Get
        Set(value As DateTime)
            _fechaRegistro = value

        End Set
    End Property

    Public Property Telefono As String
        Get
            Return _telefono

        End Get
        Set(value As String)
            _telefono = value

        End Set
    End Property

    Public Property Direccion As String
        Get
            Return _direccion

        End Get
        Set(value As String)
            _direccion = value

        End Set
    End Property

    Public Property Email As String
        Get
            Return _email

        End Get
        Set(value As String)
            _email = value

        End Set
    End Property

    Public Property Alergias As String
        Get
            Return _alergias

        End Get
        Set(value As String)
            _alergias = value

        End Set
    End Property

    Public Property Notas As String
        Get
            Return _notas

        End Get
        Set(value As String)
            _notas = value

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

    Public Sub New(pacienteID As Integer, nombrePaciente As String, apellidoPaciente As String, fechaRegistro As DateTime, telefono As String, direccion As String, email As String, alergias As String, notas As String, deleted As Boolean)
        Me.PacienteID = pacienteID
        Me.NombrePaciente = nombrePaciente
        Me.ApellidoPaciente = apellidoPaciente
        Me.FechaRegistro = fechaRegistro
        Me.Telefono = telefono
        Me.Direccion = direccion
        Me.Email = email
        Me.Alergias = alergias
        Me.Notas = notas
        Me.Deleted = deleted
    End Sub







End Class
