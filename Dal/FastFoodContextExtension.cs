using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public static class FastFoodContextExtension
    {       
        public static void Initialize(this FastFoodContext context, bool dropAlways = false)
        {
            //To drop database or not
            if (dropAlways)
                context.Database.EnsureDeleted();

            context.Database.EnsureCreated();
            
            //if db has been already seeded
            if (context.Products.Any())
                return;

            #region add burgers
            var burgers = new List<Burger>(6)
            {
                new Burger()
                {
                    Name = "Big Mick'",
                    Description = "Le seul, l'unique Big Mick' de chez Mac Mickey ! Ses deux steaks hachés, son cheddar fondu, ses oignons, ses cornichons, son lit de salade et sa sauce inimitable, font du Big Mick' un sandwich culte et indémodable.",
                    BeefWeight = 100,
                    Weight = 225,
                    Price = 4.00M,
                    //Stockpiled = 50,
                },
                new Burger()
                {
                    Name = "Royal O'Duck",
                    Description = "Fondez pour son canard pané croustillant et sa sauce légèrement vinaigrée aux oignons et aux câpres, le tout dans un pain cuit vapeur. Laissez-vous prendre dans ses filets !",
                    BeefWeight = 80,
                    Weight = 180,
                    Price = 3.90M,
                    //Stockpiled = 30,
                },
                new Burger()
                {
                    Name = "Duck Wings",
                    Description = "Craquez pour ces ailes croustillantes, à savourer avec ou sans sauce, en famille ou entre amis, faîtes-vous plaisir !",
                    BeefWeight = 25,
                    Weight = 30,
                    Price = 4.30M,
                    //Stockpiled = 100,
                },
                new Burger()
                {
                    Name = "720",
                    Description = "720 grammes de viandes! à savourer en version classique ou à la moutarde de Dijon.",
                    BeefWeight = 720,
                    Weight = 870,
                    Price = 10.90M,
                    //Stockpiled = 30,
                },
                new Burger()
                {
                    Name = "Big Wings",
                    Description = "Un généreux steak haché de canard accompagné d'emmental fondu et d'une sauce au goût grillé.",
                    BeefWeight = 150,
                    Weight = 250,
                    Price = 4.50M,
                    //Stockpiled = 0,
                },
                new Burger()
                {
                    Name = "Australian Dingo DeLuxe",
                    Description = "Craquez pour un savoureux steak de viande de dingo avec du cheddar fondu, de la salade croquante et des oignons frais, le tout accompagné d'une délicieuse sauce à la moutarde à l'ancienne qui lui donne son goût si original.",
                    BeefWeight = 120,
                    Weight = 180,
                    Price = 5.00M,
                    //Stockpiled = 8,
                },
            };
            #endregion

            #region add beverages
            var beverages = new List<Beverage>()
            {
                new Beverage()
                {
                    Name = "Coco-Cola",
                    Description = "Avec sa recette authentique et son goût unique de noix de coco, Coco-Cola nous procure plaisir, rafraîchissement et nous donne au quotidien une énergie positive incomparable... Coco-Cola, c'est du bonheur en bouteille !",
                    Price = 2.40M,
                    //Milliliter = 50,
                    IsCarbonated = true,
                    //Stockpiled = 80,
                },
                new Beverage()
                {
                    Name = "Coco-Cola Zero Coco",
                    Description = "Coco-Cola Zero Coco, c'est le goût de Coco-Cola avec zero noix de coco. Notre recette, mélange unique d'ingrédients, de caféine, d'eau pétillante, avec une touche caramel, recrée le goût de Coco-Cola.",
                    Price = 3.20M,
                    //Milliliter = 50,
                    IsCarbonated = true,
                    //Stockpiled = 60,
                },
                new Beverage()
                {
                    Name = "Biere d'Homère",
                    Description = "Oh yeah! Duffman est immortel ! Seul l'acteur qui le joue peut mourir.",
                    Price = 2.10M,
                    //Milliliter = 33,
                    IsCarbonated = true,
                    //Stockpiled = 20,
                },
                new Beverage()
                {
                    Name = "Hot Tea",
                    Description = "Laissez-vous tenter par la recette délicieusement fruitée de Hot Tea saveur Pêche et profitez de son association de thé brulant et d'arômes fruités !",
                    Price = 2.70M,
                    //Milliliter = 47,
                    IsCarbonated = false,
                    //Stockpiled = 35,
                },
                new Beverage()
                {
                    Name = "Evier",
                    Description = "McMickey s'associe à Evier® pour vous proposer des bouteilles d'eau afin d'accompagner vos menus de fraîcheur et de légèreté. ",
                    Price = 3.50M,
                    //Milliliter = 70,
                    IsCarbonated = false,
                    //Stockpiled = 15,
                },
                new Beverage()
                {
                    Name = "Café LaissePresso",
                    Description = "Pour se réveiller, rien de tel qu'un LaissePresso. Un goût intense. Profitez de sa richesse et de ses arômes dès les premières lueurs de la journée.",
                    Price = 3.00M,
                    //Milliliter = 20,
                    IsCarbonated = false,
                    //Stockpiled = 0,
                }
            };
            #endregion

            #region add sides
            var sides = new List<Side>
            {
                new Side()
                {
                    Name = "Frites",
                    Description =  "Seul ou en menu, pour combler une petite faim, en petite, moyenne ou bien grande portion, goûtez-les croustillantes et savoureuses.",
                    Price = 3.00M,
                    SaltWeight = 8,
                    Weight = 200,
                    //Stockpiled = 100,
                },
                new Side()
                {
                    Name = "Pat'a'toes",
                    Description = "Découvrez ces délicieux morceaux de pomme de terre épicés et leur sauce spéciale à la ciboulette, en accompagnement d'un menu ou pour les petites faims, ils sauront à la perfection trouver leur place sur votre plateau.",
                    Price = 3.00M,
                    SaltWeight = 9,
                    Weight = 180,
                    //Stockpiled = 60,
                },
                new Side()
                {
                    Name = "La salade Canard",
                    Description = "La salade Canard et ses tomates cerises, ses lamelles de fromage, et ses croûtons aromatisés ail et fines herbes, servie avec du canard chaud croustillant",
                    Price = 3.20M,
                    SaltWeight = 11,
                    Weight = 290,
                    //Stockpiled = 40,
                },
            };
            #endregion

            #region add desserts
            var desserts = new List<Dessert>
            {
                new Dessert()
                {
                    Name = "MacFlower",
                    Description = "un délicieux tourbillon glacé rehaussé d'un croquant et d'un nappage gourmand pour un plaisir intense !",
                    IsFrozen = true,
                    Price = 2.80M,
                    //Milliliter = 250,
                    //Stockpiled = 30,
                },
                new Dessert()
                {
                    Name = "Milk-Shake",
                    Description = "La fameuse boisson frappée à base de lait",
                    IsFrozen = false,
                    Price = 2.10M,
                    //Milliliter = 180,
                    //Stockpiled = 0,
                },
                new Dessert()
                {
                    Name = "Sunny Day",
                    Description = "Craquez pour un plaisir glacé au lait, nappage saveur chocolat ou bien caramel. Un classique McMickey's qui sied à tous les gourmands.",
                    IsFrozen = true,
                    Price = 2.60M,
                    //Milliliter = 260,
                    //Stockpiled = 50,
                },
            };
            #endregion

            #region add menus
            var menus = new List<Menu>
            {
                new Menu()
                {
                    Name = "Happy Deal",
                    Description = "Il porte bien son nom, notre Happy Deal ! Il a tout pour rendre heureux. C'est un menu varié, avec des produits que les enfants adorent et, surtout, il est bien pensé : un plat, un accompagnement, un dessert et une boisson. Un vrai repas !",
                    Price = 5.40M,
                    //Stockpiled = 1,
                    Burger = burgers[0],
                    Beverage = beverages[1],
                    Side = sides[0],
                    Dessert = desserts[0],
                },
                new Menu()
                {
                    Name = "Grand Duke McDuck",
                    Description = "Le menu Grand Duke McDuck est un classique, il allie classe et saveur avec du vrai canard de compétition. Servi naturellement avec la biere d'Homère.",
                    Price = 15.80M,
                    //Stockpiled = 1,
                    Burger = burgers[2],
                    Beverage = beverages[2],
                    Side = sides[2],
                    Dessert = desserts[2],
                },
                new Menu()
                {
                    Name = "Student McDuck",
                    Description = "Un repas à petits prix pour les étudiants ! *carte étudiante obligatoire",
                    //Stockpiled = 1,
                    Price = 12.00M,
                    Burger = burgers[3],
                    Beverage = beverages[0],
                    Side = sides[1],
                    Dessert = null,
                },
            };
            #endregion

            context.Burgers.AddRange(burgers);
            context.Beverages.AddRange(beverages);
            context.Sides.AddRange(sides);
            context.Desserts.AddRange(desserts);
            context.Menus.AddRange(menus);

            context.SaveChanges();
        }
    }
}
