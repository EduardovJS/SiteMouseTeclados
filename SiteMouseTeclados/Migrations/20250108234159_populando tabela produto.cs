using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiteMouseTeclados.Migrations
{
    /// <inheritdoc />
    public partial class populandotabelaproduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                 table: "Produtos",
                 columns: new[] { "Nome", "Resumo", "Categoria", "Valor", "ImageFileName" },
                  values: new object[,]
                    {
                        {"Arbiter Akitsu v2","Apresentamos o Vancer AKITSU Carbon Fiber Wireless Gaming Mouse – onde a inovação encontra a arte em um formato compacto e de alto desempenho. Desenvolvido em colaboração entre a Vancer e o Arbiter Studio, o AKITSU é um marco em tecnologia para jogos, projetado para gamers que exigem excelência.", "Mouse", 1529.11m, "Arbiter Akitsu v2.png"  },
                        {"Lamzu Atlantis OG v2 PRO", "O Lamzu Atlantis foi desenvolvido para jogadores exigentes que procurem controle total. O coração do mouse é seu sensor – ele determina sua precisão, o que é fundamental durante o jogo. O atlantis possui o sensor flagship do mercado PAW3395 e permite ajuste da escala DPI entre 200 a 26000 DPI", "Mouse", 944.91m, "Lamzu Atlantis OG v2 PRO .png"  },
                        {"Logitech G PRO X TKL Lightspeed Tactile", "Tecnologia PRO-Grade: Controle modo jogo, layouts de teclado padrão para compatibilidade 3P, controles de mídia e botão de volume, iluminação RGB com opções LIGHTSYNC, e LIGHTSPEED, Bluetooth e USB" , "Teclado", 1259.91m, "Logitech G PRO X TKL Lightspeed Tactile.png"},
                        {"Ninjutso Sora v2", "O Sora v2 é o mouse gamer sem fio mais leve do mundo, pesando apenas 39 gramas e construído em policarbonato de alta resistência. Projetado com foco no desempenho ideal, o Sora v2 incorpora a inovadora tecnologia sem fio SnappyFire", "Teclado" , 1149.90m, "Ninjutso Sora v2.png"},
                        {"Wooting Two HE", "O Wooting Two HE detecta o movimento total do interruptor com precisão de 0,1 mm do início ao fim. Cada tecla emite um sinal analógico que pode ser usado para vários recursos que aprimoram sua experiência de digitação e jogo. Bem vindo ao futuro", "Teclado", 2609.91m, "Wooting Two HE.png"}
                  });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
               table: "Produtos",
               keyColumn: "Nome",
               keyValues: new object[] { "Arbiter Akitsu v2", "Lamzu Atlantis OG v2 PRO", "Logitech G PRO X TKL Lightspeed Tactile", "Ninjutso Sora v2", "Wooting Two HE" });
        }
    }
}
