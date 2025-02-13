CREATE TABLE [dbo].[Patient](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PatientId] [varchar](50) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[PhoneNumber] [varchar](50) NULL,
	[DiseaseName] [varchar](250) NOT NULL,
	[DateOfBirth] [date] NULL
) ON [PRIMARY]
GO


-----------------------------------------------------------
CREATE PROCEDURE InsertPatient
	@PatientId Varchar(50),
	@Name Varchar(100),
	@PhoneNumber Varchar(50),
	@DiseaseName Varchar(250),
	@DateOfBirth Date
AS
BEGIN
	
	INSERT INTO Patient([PatientId],[Name],[PhoneNumber],[DiseaseName],[DateOfBirth])VALUES
	(@PatientId,@Name,@PhoneNumber,@DiseaseName,@DateOfBirth);

END
GO

-------------------------------------------------------------------------------

CREATE PROCEDURE GetPatientByPatientId
	@PatientId Varchar(50)
AS
BEGIN
	
	SELECT *FROM Patient WHERE PatientId = @PatientId

END
GO
