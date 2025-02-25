/*
 * @fileoverview    {Meal}
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

namespace Project.Models {

    /**
     * TODO: Description of {@code Meal}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class Meal {

        [Key]
        public Int64? IntMealId { get; set; }
        public String? StrName { get; set; }
        public Single? FltPrice { get; set; }
        public Int64? IntChefId { get; set; }

    }

}