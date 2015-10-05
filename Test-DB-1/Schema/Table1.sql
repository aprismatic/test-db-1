CREATE TABLE [dbo].[Table1]
(
	[rowId] UNIQUEIDENTIFIER NULL DEFAULT NEWID(),
	[col1.Paillier.Enc] VARBINARY(MAX) NULL,
	[col1.Fingerprint] INT NULL,
	[col2.Paillier.Enc] VARBINARY(MAX) NULL,
	[col2.Fingerprint] INT NULL,
	[col3.Paillier.Enc] VARBINARY(MAX) NULL,
	[col3.Fingerprint] INT NULL,
    [Common.Paillier.N] VARBINARY(MAX) NULL
)

GO

CREATE INDEX [IX_Table1_col1] ON [dbo].[Table1] ([col1.Fingerprint])

GO

CREATE INDEX [IX_Table1_col2] ON [dbo].[Table1] ([col2.Fingerprint])

GO

CREATE INDEX [IX_Table1_rowId] ON [dbo].[Table1] ([rowId])
