﻿using CandyShop.Models;
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
        private readonly ProductContext _context;
        // Static products list
        public static List<ProductModel> Products { get; set; } = new List<ProductModel>();
        // List of database products and static list products
        public static List<ProductModel> AllProducts { get; set; } = new List<ProductModel>();
        public IList<ProductModel> ProductModel { get; set; }


        public ProductManager(ProductContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Method to combine database product list and hardcoded product list into one list
        /// </summary>
        /// <returns></returns>
        public List<ProductModel> GetAllProducts()
        {
            //List<ProductModel> GetAllProducts = new List<ProductModel>();

            var dbProducts = _context.Products.ToList();

            AllProducts = Products.Concat(dbProducts).ToList();

            AllProducts = AllProducts.OrderBy(product => product.Name).ToList();

            return AllProducts;
        }
        /// <summary>
        /// Method to search for products
        /// </summary>
        /// <param name="SearchTerm"></param>
        /// <returns></returns>
        public IEnumerable<ProductModel> Search(string SearchTerm)
        {
            List<ProductModel> Products = AllProducts;
            if (string.IsNullOrEmpty(SearchTerm))
            {
                return AllProducts;
            }

            var lowercaseSearchText = SearchTerm.ToLower();
            var filteredProducts = AllProducts.Where(product => product.Name.ToLower().Contains(lowercaseSearchText));

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
                        ImageUrl = "Bilar.jpg"
                    },

                    new ProductModel()
                    {
                        Id = 200,
                        Name = "Coca-Cola Sleek Can 33 cl",
                        Category = "Soda",
                        Description = "Priset är inklusive pant",
                        Price = 12,
                        ImageUrl = "Cola-Burk.jpg"
                    },

                    new ProductModel()
                    {
                        Id = 300,
                        Name = "Coca-Cola Vanilla Zero Sleek Can 33 cl",
                        Category = "Soda",
                        Description = "Priset är inklusive pant",
                        Price = 12,
                        ImageUrl = "ColaVanilj-Burk.jpg"
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
                        ImageUrl = "CrispyBacon.jpg"
                    },

                    new ProductModel()
                    {
                        Id = 500,
                        Name = "Malaco Djungelvrål 80 gr",
                        Category = "Candy",
                        Description = "Näringsvärde per 100.0 gram Energi 345.0/1475.0 kilokalori/kilojoule Fett 0.0 gram varav mättat fett 0.0 gram " +
                                      "Kolhydrat 91.0 gram varav sockerarter 47.0 gram Protein 0.4 gram Salt 0.18 gram",
                        Price = 10,
                        ImageUrl = "Djungelvral.jpg"
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
                        ImageUrl = "EstrellaCheddarSourcream.jpg"
                    },


                };
            }

            return Products;
        }
    }
}
