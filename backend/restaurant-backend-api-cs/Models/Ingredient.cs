/*
 * @fileoverview    {Ingredient}
 *
 * @version         2.0
 *
 * @author          Dyson Arley Parra Tilano <dysontilano@gmail.com>
 *
 * @copyright       Dyson Parra
 * @see             github.com/DysonParra
 *
 * History
 * @version 1.0     Implementation done.
 * @version 2.0     Documentation added.
 */
using System;
using System.ComponentModel.DataAnnotations;

/**
 * TODO: Definición de {@code Ingredient}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class Ingredient {

        [Key]
        public Int64? IntIngredientId { get; set; }
        public String? StrIngredientName { get; set; }
        public String? StrDescription { get; set; }
        public Int64? IntMealId { get; set; }

    }

}