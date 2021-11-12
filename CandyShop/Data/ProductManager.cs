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
        public IList<ProductModel> ProductModel { get; set; }

        private ProductContext _context;

        public void AllProductsModel(ProductContext context)
        {
            _context = context;
        }
        public async Task GetDbProducts()
        {
            ProductModel = await _context.Products.ToListAsync();
        }

        public static IEnumerable<ProductModel> Search(string SearchTerm)
        {
            if (string.IsNullOrEmpty(SearchTerm))
            {
                return (Products, _context);
            }
            var lowercaseSearch = SearchTerm.ToLower();

            return Products.Where(product => product.Name.ToLower().Contains(lowercaseSearch));
        }
        public static List<ProductModel> Products { get; set; } = new List<ProductModel>();

        public static List<ProductModel> GetProducts()
        {
            if (!Products.Any())
            {
                Products = new List<ProductModel>()
                {
                    new ProductModel()
                    {
                        Id = 1,
                        Name = "Bilar", 
                        Category = "Candy",
                        Description = "Glukossirap, socker, stärkelse, gelatin, invertsockersirap, syra (E270), " +
                                      "kokosolja, aromer, ytbehandlingsmedel (karnaubavax), färgämnen (E141, E120). " +
                                      "Näringsinformation: Näringsvärde per 100.0 gram Energi 350.0/1475.0 kilokalori/kilojoule " +
                                      "Fett 0.2 gram varav mättat fett 0.2 gram Kolhydrat 83.0 gram varav sockerarter 57.0 gram " +
                                      "Protein 4.4 gram Salt 0.01 gram",
                        Price = 10, 
                        ImageUrl = "Bilar.jpg"
                    },

                    new ProductModel()
                    {
                        Id = 2,
                        Name = "Coca-Cola Sleek Can 33 cl",
                        Category = "Soda",
                        Description = "Priset är inklusive pant",
                        Price = 12,
                        ImageUrl = "Cola-Burk.jpg"
                    },

                    new ProductModel()
                    {
                        Id = 3,
                        Name = "Coca-Cola Vanilla Zero Sleek Can 33 cl",
                        Category = "Soda",
                        Description = "Priset är inklusive pant",
                        Price = 12,
                        ImageUrl = "ColaVanilj-Burk.jpg"
                    },

                    new ProductModel()
                    {
                        Id = 4,
                        Name = "Crispy Bacon 175 gr",
                        Category = "Chips",
                        Description = "Ingredienser: 60% Vetemjöl (VETE), solrosolja, salt, bakpulver (natriumhydrogenkarbonat), " +
                                      "färgemne (sockerkulör, ammoniakprocessen, karmin, vegetabiliskt kol), maltodextrin, " +
                                      "smakförstärkare (mononatriumglutamat, dinatrium-5′-ribonukleotider), socker, lök, jästextrakt, " +
                                      "paprika, kryddextrakt (gurkmeja, paprika), surhetsreglerande medel (mjölksyra), propylenglukol, " +
                                      "raps-/kokosolja, rökarom, emulgeringsmedel (mono- och diglyceriders ättiksyraestrar), arom, " +
                                      "förtjockningsmedel (gummi arabicum).",
                        Price = 20,
                        ImageUrl = "CrispyBacon.jpg"
                    },

                    new ProductModel()
                    {
                        Id = 5,
                        Name = "Malaco Djungelvrål 80 gr",
                        Category = "Candy",
                        Description = "Näringsvärde per 100.0 gram Energi 345.0/1475.0 kilokalori/kilojoule Fett 0.0 gram varav mättat fett 0.0 gram " +
                                      "Kolhydrat 91.0 gram varav sockerarter 47.0 gram Protein 0.4 gram Salt 0.18 gram",
                        Price = 10,
                        ImageUrl = "Djungelvral.jpg"
                    },

                    new ProductModel()
                    {
                        Id = 6,
                        Name = "Estrella Cheddar & Sourcream 175 g",
                        Category = "Chips",
                        Description = "Potatis, solros-/rapsolja, kryddblandning (salt, VASSLEpulver (från MJÖLK), socker, lökpulver, MJÖLKprotein, " +
                                      "druvsocker, OSTpulver 6% (varav 60% Cheddar), LAKTOS, syra (mjölk- och citronsyra), jästextrakt, vitlök, " +
                                      "persilja, naturlig arom, färgämne (paprikaextrakt)).",
                        Price = 20,
                        ImageUrl = "EstrellaCheddarSourcream.jpg"
                    },


                };
            }

            return Products;
        }





    }
}
