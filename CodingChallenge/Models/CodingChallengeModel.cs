using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodingChallenge.Models
{
    public class Column
    {
        public Column()
        {
            this.Boxes = new List<Box>();
        }

        public int ColumnNumber { get; set; }
        public decimal ColumnOpacity { get; set; }
        public List<Box> Boxes { get; set; }
    }

    public class Box
    {
        public Box(decimal value)
        {
            Value = value;
        }

        public decimal Value { get; set; }
        public int HeightPercent { get; set; }
        public decimal Modulus { get; set; }
    }

    public class CodingChallengeModel
    {
        public CodingChallengeModel(IEnumerable<CodingChallengeDto> codingChallengeDto)
        {
            MapColumns(codingChallengeDto);
            ColumnWidth = 100 / Convert.ToDecimal(Columns.Count());
        }

        public decimal ColumnWidth { get; set; }
        public List<Column> Columns { get; set; }

        private void MapColumns(IEnumerable<CodingChallengeDto> codingChallengeDto)
        {
            Columns = new List<Column>();

            foreach (var c in codingChallengeDto)
            {
                var totalBoxHeight = c.Box0 + c.Box1 + c.Box2 + c.Box3 + c.Box4 + c.Box5 + c.Box6 + c.Box7 + c.Box8 + c.Box9 + c.Box10 + c.Box11;
                int totalHeight = 0;

                var boxes = new List<Box>();
                boxes.Add(new Box(c.Box0));
                boxes.Add(new Box(c.Box1));
                boxes.Add(new Box(c.Box2));
                boxes.Add(new Box(c.Box3));
                boxes.Add(new Box(c.Box4));
                boxes.Add(new Box(c.Box5));
                boxes.Add(new Box(c.Box6));
                boxes.Add(new Box(c.Box7));
                boxes.Add(new Box(c.Box8));
                boxes.Add(new Box(c.Box9));
                boxes.Add(new Box(c.Box10));
                boxes.Add(new Box(c.Box11));

                foreach (var box in boxes)
                {
                    var heightPercent = (box.Value / totalBoxHeight) * 100;
                    box.HeightPercent = Convert.ToInt32(Math.Floor(heightPercent));
                    box.Modulus = heightPercent % 1;
                    totalHeight += box.HeightPercent;
                }

                var sortedByLargestModulus = boxes.OrderBy(x => x.Modulus).Reverse().ToList();

                var remainder = 100 - totalHeight;

                for (var i = 0; i < remainder; i++)
                {
                    sortedByLargestModulus[i].HeightPercent += 1;
                }

                Columns.Add(new Column { 
                    Boxes = boxes, 
                    ColumnNumber = c.Column, 
                    ColumnOpacity = c.ColumnOpacity
                });
                
            }
        }
    }
}