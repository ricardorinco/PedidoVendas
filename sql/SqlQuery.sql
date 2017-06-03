﻿CREATE TABLE [dbo].[Cliente] (
    [Id] [int] NOT NULL IDENTITY,
    [Nome] [varchar](150) NOT NULL,
    [CPF] [varchar](14) NOT NULL,
    CONSTRAINT [PK_dbo.Cliente] PRIMARY KEY ([Id])
)
CREATE TABLE [dbo].[Pedido] (
    [Id] [int] NOT NULL IDENTITY,
    [DataEntrega] [datetime] NOT NULL,
    [NumeroControle] [int] NOT NULL,
    [ClienteId] [int],
    CONSTRAINT [PK_dbo.Pedido] PRIMARY KEY ([Id])
)
CREATE TABLE [dbo].[Item] (
    [Id] [int] NOT NULL IDENTITY,
    [Quantidade] [decimal](3, 2) NOT NULL,
    [ProdutoId] [int] NOT NULL,
    [PedidoId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.Item] PRIMARY KEY ([Id])
)
CREATE TABLE [dbo].[Produto] (
    [Id] [int] NOT NULL IDENTITY,
    [Descricao] [varchar](200) NOT NULL,
    [Valor] [decimal](18, 2) NOT NULL,
    CONSTRAINT [PK_dbo.Produto] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_ClienteId] ON [dbo].[Pedido]([ClienteId])
CREATE INDEX [IX_ProdutoId] ON [dbo].[Item]([ProdutoId])
CREATE INDEX [IX_PedidoId] ON [dbo].[Item]([PedidoId])
ALTER TABLE [dbo].[Pedido] ADD CONSTRAINT [FK_dbo.Pedido_dbo.Cliente_ClienteId] FOREIGN KEY ([ClienteId]) REFERENCES [dbo].[Cliente] ([Id])
ALTER TABLE [dbo].[Item] ADD CONSTRAINT [FK_dbo.Item_dbo.Pedido_PedidoId] FOREIGN KEY ([PedidoId]) REFERENCES [dbo].[Pedido] ([Id])
ALTER TABLE [dbo].[Item] ADD CONSTRAINT [FK_dbo.Item_dbo.Produto_ProdutoId] FOREIGN KEY ([ProdutoId]) REFERENCES [dbo].[Produto] ([Id])
CREATE TABLE [dbo].[__MigrationHistory] (
    [MigrationId] [nvarchar](150) NOT NULL,
    [ContextKey] [nvarchar](300) NOT NULL,
    [Model] [varbinary](max) NOT NULL,
    [ProductVersion] [nvarchar](32) NOT NULL,
    CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY ([MigrationId], [ContextKey])
)
INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
VALUES (N'201706020528445_AutomaticMigration', N'RR.PedidoVendas.Infrastructure.Data.Migrations.Configuration',  0x1F8B0800000000000400ED5BCD6EE33610BE17E83B083A16592BCEA2C036B077B17592C2E8E6A771B2E82D6024DA112A512A45050E8A3E590F7DA4BE4287A2445114F59B380982C55ED61439339CF9E6871CE6BF7FFE9D7DDA8681758F69E247646E4F27FBB685891B793ED9CCED94ADDF7DB03F7DFCFEBBD9B1176EADAFC5BCF77C1EAC24C9DCBE632C3E749CC4BDC3214A26A1EFD22889D66CE246A183BCC839D8DFFFC9994E1D0C246CA06559B3CB94303FC4D90FF8B988888B6396A2E034F27090E4E3F0659551B5CE50889318B9786E5F5E4E2EB0E77BD1574C3CE0B7246B8A12465397A5144F8E104313A0C7F096D9D6E7C04720E20A076BDB4284440C31D8C0E17582578C4664B38A610005570F3186796B142438DFD86139BDEF1EF70FF81E9D726141CA4D13168503094EDFE74A73F4E5A3546F4BA5825A8F41FDEC81EF3A53EDDC5E043E069DD996CEEB7011503EAFAEF82398E69389B0D82427B06799A7ED49EC00C4F8BF3D6B9106DC627382534651B0675DA4B781EFFE8A1FAEA23F309993340854A1416CF8561980A10B1AC598B2874BBCCEB7B2F46CCBA9AE73F4857299B246EC7249D8FB03DB3A03E6E836C012138A46562CA2F8174C30450C7B1788314C09A78133ADD6B86BBCCEA21017DC0084E068B6758AB65F30D9B03B70C11FC1B54EFC2DF68A915C826BE2835FC222C03A3648D8CE757171D2C674AAF1143C06B23C43F7FE26D391C65C0022B1AD4B1C64DF933B3F166E9983E54602F08446E16514C855C5979B2B4437187CFA2A327E5E4529753599664E09F456F80B5AE3D12F3E7D037F27F8797806ED53BC41055318C2577E381CD267698869C4633D054074EDA1C33D048A6AAAE88B7009DFC720BC807003C20B07E82BD3926162F639F812DE14982FC551866BDEA67E7B94AB7142E31D8DAFFEE6669D6EF65B8A609E873CE91647D8F54314D8D60585FFE5559C6DAD5CC40518EE30F0D34B59D4BDA90E3299190753E9C8346341AF3BA0C9217A4B2214D4224A314197458C3708937F3449D33FDB159C47A73B41E09B2376E73B9CB8D47751D4527C4191BE8B8AEF2B0A22DAE6FED30F43FC7F749AE980B939D1683ED007E69F932472FD4C864A309089B7BA9F63E259ED5958D8ABCCE0603440B11F036E81FDDCFEA1A6A3469A7293254D590E5489EE4F26D31A5DC03BA61C70288072070EBBE064ACEE1C3E71FD1805AD2268AB7A3A15D7BAA4AF7F39C231783F3069D5671FC64A1556E72FD968EEDEA59C99A320A31D306A8A68B2AC315F946615E54D7FA0186BAE2EE43D11420CBC9F011E0605F6E15A560A2F088D3C96B51B53CFDF8F05871E28157414B17587F0A8727F367C5495D80B206545FA0C081139881F3E6105A6CAF1565E3ED6AAABEB04E7055692E774DDF09CE60AB36A3884E45A663C3D7BD4B05325216F5E6A148AC8D24120CFEEB5E502CA5DDC85498CEC0BE86A241475EBBB284FD0CA24F3195BB77F67B297922B2AABA1A833BD2B544ADBE9E56975873D765F39B8D4B7DE98B43AD396226E6EE6962D9B1255B7D6466FB78047D37E4D91B83B168FD8B1167DD52D4B74F7DE7351BBCAB851763A1CD1EA285A224E434F64768AE2184E104A8F241FB156A241B278B71ADE2008050DC74D0C7D0229ADE4048722B4C1DA57600D929EF834613C0EDE227E8A5878616D9A1A251B0248C1490B8475631561A558C0FF2F160D68144D1AE246A9DC13D86FC87354761EACFB797D65D6BC4201A286D3E7220AD2903467CBE6D5A279A0AE1723FD29648D00954036505F3F73B4ADD7726A4DF99A17E8C6EC65EA228EECCAD2E640D9C3D04D0B7763E7CA3DB94AA6F261006EB4BBF20A82B46F03B0549ED72A886A3EC6BD18AE44B8DF15AAB26A6838A6CCCB768328F54A58A5A28EF7A7A614DB2AB1961ABC85963CD95548359EF75E2E3615097F67C1C95CD5F4894E4D2B77149ECA6BCD4A702A87FBD3CAEF29553AF9D0331BBE569CE953247759A469C5D82C2F8CBA5FB1D42A253185DFCF46F7BEC7ABA4D54302E1410064F56720826A39E114117F8D1326EECFED83FDE981F6DEE5F5BC3D7192C40BFA3D4079F61E80CF95DA79CB3FB435ADBCF1B847D4BD43B4FEC863FC0B0E23C96907C5A18F21DE86250C0F0E3CA0CC9EEEC14126F6639F1B64446A17464BE2E1EDDCFE2B5B75682D7FBF910BF7AC730A51E0D0DAB7FE56D98B56D1F8CEFCDBB07ABDFFEDEDBAFFDDD7827261930547F5CD7B73CFD70D603EB8ADFC362054EBDC9A826ED6BA7D4C5FD604CB017DD927EF85CA2BD6919D4AFD8A74541B7554B7A2F90A67470DCE37D3D1EC6DA936738B7EC0E05ED7233ADBCFD58B7A33DD4979A73EA683F842966E3C10BFA0A95F419FB17ED1DE7081A13F4F6D6E248A032864A45B8E1091718675195B9A8C26E2FD1B906163FFD144774867B2AD316994F985BA969AFD2A9D87EE3EA5A151F75ADA92BD05348420FD22F5D5B41E3570552EE876B9AD01DDC5FA4515C428E58FB2203C26FEA624C1FF448B60B7129DE49C255947459CD4242AA66835F02966088EE1E83365FE1AB90C3EBB3849B29791501FA730E538BCC5DE929CA72C4E196C1987B741E5B9250FB66DFCB3166A55E6D9799C3D517C8A2D80983EBF4938273FA77EE049B94F0C557A03091EC5F3130BB725E32797CD83A47416919E8472F5C9E47385C3380062C93959A17B3C46B6EB047FC11BE43E14F78DCD44BA0D5155FBECC8471B8AC224A751AE879F80612FDC7EFC1F6819A4639B380000 , N'6.1.3-40302')

