using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing.Models
{
    // Simple data model
    public class Pet
    {
        public string Image { get; set; } = "siam_lilacpoint.jpg";
        public string Name { get; set; } = "Robin Hood";
        public string Breed { get; set; } = "Pug";
        public string GenderSymbol { get; set; } = "♂";
        public string AgeText { get; set; } = "1 year old";
        public string Address { get; set; } =
            "38, Lorong 88, Taman Rantau Panjang, 96000 Sibu, Sarawak";
        public string OwnerName { get; set; } = "哈基米(Hajimi)";
        public string OwnerAvatar { get; set; } = "elon_musk.jpg";
        public string DateText { get; set; } = "1.11.2024";
        public string Description { get; set; } =
            "Hi! Robin the Pug is simply a tiny tornado of fur, wrinkles, and endless charm!";
    }
}

