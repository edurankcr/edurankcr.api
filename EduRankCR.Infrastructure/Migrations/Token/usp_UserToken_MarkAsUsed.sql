﻿CREATE PROCEDURE usp_UserToken_MarkAsUsed
    @Token NVARCHAR(255)
AS
BEGIN
    DELETE FROM Users_Tokens
    WHERE Token = @Token;
END
