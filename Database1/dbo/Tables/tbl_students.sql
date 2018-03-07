CREATE TABLE [dbo].[tbl_students] (
    [ID]        INT          IDENTITY (1, 1) NOT NULL,
    [StdEmail]  VARCHAR (50) NOT NULL,
    [StdFName]  VARCHAR (50) NOT NULL,
    [StdLName]  VARCHAR (50) NOT NULL,
    [StdGender] VARCHAR (50) NOT NULL,
    [Password]  VARCHAR (50) NOT NULL,
    [Confirm]   VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_tbl_students] PRIMARY KEY CLUSTERED ([ID] ASC)
);

