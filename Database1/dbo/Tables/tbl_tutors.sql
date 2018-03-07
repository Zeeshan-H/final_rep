CREATE TABLE [dbo].[tbl_tutors] (
    [ID]       INT          IDENTITY (1, 1) NOT NULL,
    [Email]    VARCHAR (50) NOT NULL,
    [FName]    VARCHAR (50) NOT NULL,
    [LName]    VARCHAR (50) NOT NULL,
    [Gender]   VARCHAR (50) NOT NULL,
    [Password] VARCHAR (50) NOT NULL,
    [Confirm]  VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_tbl_tutors] PRIMARY KEY CLUSTERED ([ID] ASC)
);

