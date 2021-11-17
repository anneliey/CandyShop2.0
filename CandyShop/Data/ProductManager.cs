using CandyShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CandyShop.Data;

namespace CandyShop.Data
{
    public class ProductManager
    {
        private ProductContext _context;

        public static List<ProductModel> Products { get; set; } = new List<ProductModel>();
        public IList<ProductModel> ProductModel { get; set; }

        public ProductManager(ProductContext context)
        {
            _context = context;
        }

        public IEnumerable<ProductModel> Search(string SearchTerm)
        {
            var dbProducts = _context.Products.ToList();

            var combinedProducts = Products.Concat(dbProducts).ToList();

            if (string.IsNullOrEmpty(SearchTerm))
            {
                return combinedProducts;
            }

            var lowercaseSearchText = SearchTerm.ToLower();
            var filteredProducts = combinedProducts.Where(product => product.Name.ToLower().Contains(lowercaseSearchText));

            return filteredProducts;
        }
        
        public static List<ProductModel> GetProducts()
        {
          
            if (!Products.Any())
            {
                Products = new List<ProductModel>()
                {
                    new ProductModel()
                    {
                        Id = 100,
                        Name = "Bilar", 
                        Category = "Candy",
                        Description = "Glukossirap, socker, stärkelse, gelatin, invertsockersirap, syra (E270), " +
                                      "kokosolja, aromer, ytbehandlingsmedel (karnaubavax), färgämnen (E141, E120). " +
                                      "Näringsinformation: Näringsvärde per 100.0 gram Energi 350.0/1475.0 kilokalori/kilojoule " +
                                      "Fett 0.2 gram varav mättat fett 0.2 gram Kolhydrat 83.0 gram varav sockerarter 57.0 gram " +
                                      "Protein 4.4 gram Salt 0.01 gram",
                        Price = 10, 
                        ImageUrl = "Bilar.jpg",
                        Stock = 10,
                    },

                    new ProductModel()
                    {
                        Id = 200,
                        Name = "Coca-Cola Sleek Can 33 cl",
                        Category = "Soda",
                        Description = "Priset är inklusive pant",
                        Price = 12,
                        ImageUrl = "Cola-Burk.jpg",
                        Stock = 10,
                    },

                    new ProductModel()
                    {
                        Id = 300,
                        Name = "Coca-Cola Vanilla Zero Sleek Can 33 cl",
                        Category = "Soda",
                        Description = "Priset är inklusive pant",
                        Price = 12,
                        ImageUrl = "ColaVanilj-Burk.jpg",
                        Stock = 10,
                    },

                    new ProductModel()
                    {
                        Id = 400,
                        Name = "Crispy Bacon 175 gr",
                        Category = "Chips",
                        Description = "Ingredienser: 60% Vetemjöl (VETE), solrosolja, salt, bakpulver (natriumhydrogenkarbonat), " +
                                      "färgemne (sockerkulör, ammoniakprocessen, karmin, vegetabiliskt kol), maltodextrin, " +
                                      "smakförstärkare (mononatriumglutamat, dinatrium-5′-ribonukleotider), socker, lök, jästextrakt, " +
                                      "paprika, kryddextrakt (gurkmeja, paprika), surhetsreglerande medel (mjölksyra), propylenglukol, " +
                                      "raps-/kokosolja, rökarom, emulgeringsmedel (mono- och diglyceriders ättiksyraestrar), arom, " +
                                      "förtjockningsmedel (gummi arabicum).",
                        Price = 20,
                        ImageUrl = "CrispyBacon.jpg",
                        Stock = 10,
                    },

                    new ProductModel()
                    {
                        Id = 500,
                        Name = "Malaco Djungelvrål 80 gr",
                        Category = "Candy",
                        Description = "Näringsvärde per 100.0 gram Energi 345.0/1475.0 kilokalori/kilojoule Fett 0.0 gram varav mättat fett 0.0 gram " +
                                      "Kolhydrat 91.0 gram varav sockerarter 47.0 gram Protein 0.4 gram Salt 0.18 gram",
                        Price = 10,
                        ImageUrl = "Djungelvral.jpg",
                        Stock = 10,
                    },

                    new ProductModel()
                    {
                        Id = 600,
                        Name = "Estrella Cheddar & Sourcream 175 g",
                        Category = "Chips",
                        Description = "Potatis, solros-/rapsolja, kryddblandning (salt, VASSLEpulver (från MJÖLK), socker, lökpulver, MJÖLKprotein, " +
                                      "druvsocker, OSTpulver 6% (varav 60% Cheddar), LAKTOS, syra (mjölk- och citronsyra), jästextrakt, vitlök, " +
                                      "persilja, naturlig arom, färgämne (paprikaextrakt)).",
                        Price = 20,
                        ImageUrl = "EstrellaCheddarSourcream.jpg",
                        Stock = 10,
                    },

                    new ProductModel()
                    {
                        Id = 7,
                        Name = "Fanta Exotic 33 cl",
                        Category = "Soda",
                        Description = "Priset är inklusive pant",
                        Price = 12,
                        ImageUrl = "FantaExotic-Burk.jpg",
                        Stock = 10,
                    },

                    new ProductModel()
                    {
                        Id = 8,
                        Name = "Malaco Fizzypop 80 gr",
                        Category = "Candy",
                        Description = "Glukossirap, socker/sukker, vatten/vand, gelatin, syra (citronsyra), " +
                        "färgämnen/farvestoffer (e170, e120, e133), fullhärdat/helt hærdet/fullherdet palmfett, arom..",
                        Price = 10,
                        ImageUrl = "Fizzypop - kopia.jpg",
                        Stock = 10,
                    },

                    new ProductModel()
                    {
                        Id = 9,
                        Name = "Haribo Nappar Frukt 80 gr",
                        Category = "Candy",
                        Description = "Glukossirap; socker; gelatin; druvsocker; syra: citronsyra; frukt- och plantkoncentrat: spirulina, " +
                        "safflor, äpple, citron, rättika, sötpotatis, morot, svarta vinbär, hibiskus; invertsockersirap; arom; " +
                        "palmolja; ytbehandlingsmedel: bivax vitt och gult, karnaubavax.",
                        Price = 10,
                        ImageUrl = "HariboNappar - kopia.jpg",
                        Stock = 10,
                    },
                    new ProductModel()
                    {
                        Id = 10,
                        Name = "Haribo Nappar Sour 80 gr",
                        Category = "Candy",
                        Description = "Socker, glukossirap, gelatin, surhetsreglerande medel (citronsyra, fumarsyra), " +
                        "frukt och plantkoncentrat (apelsin, citron, kiwi, svarta vinbär, tistel, röda vinbär, mango, morot, " +
                        "passionsfrukt, vindruvor, nässla, spenat, äpple, fläder, aronia), aromämnen, karamelliserat socker, " +
                        "fruktsocker, invertsockersirap.",
                        Price = 10,
                        ImageUrl = "HariboNapparSur - kopia.jpg",
                        Stock = 10,
                    },
                     new ProductModel()
                    {
                        Id = 11,
                        Name = "Haribo Starmix 80 gr",
                        Category = "Candy",
                        Description = "Glukossirap; socker; gelatin; druvsocker; fruktjuice från koncentrat: äpple, jordgubbar, hallon, " +
                        "apelsin, citron, ananas; syra: citronsyra; frukt- och plantkoncentrat: safflor, spirulina, äpple, fläderbär, apelsin, " +
                        "svarta vinbär, kiwi, citron, aronia, mango, passionsfrukt, rättika, sötpotatis, morot, hibiskus, vindruva; invertsockersirap; " +
                        "karamelliserat socker; arom; extrakt av fläderbär; palmolja; ytbehandlingsmedel: bivax vitt och gult, karnaubavax..",
                        Price = 10,
                        ImageUrl = "Haribo-Starmix.jpg",
                        Stock = 10,
                    },
                      new ProductModel()
                    {
                        Id = 12,
                        Name = "Estrella Jordnötsringar 175 gr",
                        Category = "Chips",
                        Description = " Jordnötssmör 29% (malda rostade jordnötter, druvsocker, salt), majsmjöl, rismjöl, solros-/rapsolja, " +
                        "kornmjöl, rågmjöl, socker, salt, druvsocker, vetemjöl.",
                        Price = 20,
                        ImageUrl = "Jordnotsringar.jpg",
                        Stock = 10,
                    },
                       new ProductModel()
                    {
                        Id = 13,
                        Name = "Estrella Linschips Ranch & Sourcream 110 g",
                        Category = "Chips",
                        Description = " Linsmjöl (38%), majsmjöl, rismjöl, solros-/rapsolja, kryddblandning (socker, salt, druvsocker, tomatpulver, " +
                        "maltodextrin, lökpulver, syra (mjölksyra, citronsyra, äpplesyra), jästextrakt, vitlök, paprika, kaliumklorid, " +
                        "krydda (svartpeppar, chili), persilja, paprikaextrakt, naturlig arom), majsstärkelse, potatisstärkelse, grönpepparpulver.",
                        Price = 15,
                        ImageUrl = "Linschips.jpg",
                        Stock = 10,
                    },
                };
            }

            return Products;
        }





    }
}
