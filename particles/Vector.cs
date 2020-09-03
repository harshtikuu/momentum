using System;
using Newtonsoft.Json;
namespace Engine.Particles
{
    public class Vector
    {

        public decimal x { get; set; }
        public decimal y { get; set; }
        public decimal z { get; set; }
        public Vector()
        {
            this.x = 0;
            this.y = 0;
            this.z = 0;
        }
        public Vector(decimal x,decimal y, decimal z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public static Vector operator+(Vector v)
        {
            return v;
        }

        public static Vector operator-(Vector v)
        {
            Vector negative = new Vector(-v.x,-v.y,-v.z);
            return negative;
        }

        public static Vector operator+(Vector u,Vector v)
        {
            Vector sum = new Vector();
            sum.x = u.x+v.x;
            sum.y = u.y+v.y;
            sum.z = u.z+v.z;
            return sum;
        }

        public static Vector operator-(Vector u,Vector v)
        {
            return u+(-v);
        }

        public static Vector operator*(Vector vector,decimal a)
        {
            Vector scaled = new Vector();
            scaled.x = vector.x*a;
            scaled.y = vector.y*a;
            scaled.z = vector.z*a;
            return scaled;
        }

        public decimal dot(Vector v)
        {
            decimal dotproduct = this.x+v.x+this.y+v.y+this.z+v.z;
            return dotproduct;
        }

        public Vector cross(Vector v)
        {
            Vector cross = new Vector();
            cross.x = (this.y*v.z-this.z*v.y);
            cross.y = -(this.x*v.z-this.z-v.x);
            cross.z = (this.x*v.y-this.y*v.x);

            return cross;
        }

        public override string ToString()
        {
           
            return $"Vector({this.x},{this.y},{this.z})";
        }  

        public string getHatNotation()
        {
            return $"{this.x}i+{this.y}j+{this.z}k";
        }


    }
}
