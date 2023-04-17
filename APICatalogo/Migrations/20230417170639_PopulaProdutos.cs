using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalogo.Migrations
{
    public partial class PopulaProdutos : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Produtos(Nome, Descricao,Preco,ImagemUrl,Estoque,DataCadastro,CategoriaId)" +
                "Values ('Coca-Cola Diet', 'Refrigerante de Cola 350 ml',5.45,'cocacola.jpg',50,'2023/04/17',1)");

            mb.Sql("Insert into Produtos(Nome, Descricao,Preco,ImagemUrl,Estoque,DataCadastro,CategoriaId)" +
    "Values ('Lanche de Atum', 'Lanche de Atum com Maionese',8.50,'atum.jpg',10,'2023/04/17',2)");

            mb.Sql("Insert into Produtos(Nome, Descricao,Preco,ImagemUrl,Estoque,DataCadastro,CategoriaId)" +
    "Values ('Pudim 100g', 'Pudim de leite condensado 100g',6.75,'pudim.jpg',20,'2023/04/17',3)");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Produtos");
        }
    }
}
