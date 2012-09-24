using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
#pragma warning disable 660,661

namespace AutoGenerated
{
	public class Vehicles
	{
		public virtual IList<Car> Cars { get; set; }

		public Vehicles(XElement element)
		{
			Cars = element.Elements().Where(e => e.Name == "car").Select(e => new Car(e)).ToList();
		}

		public Vehicles()
		{ }

		public static bool operator ==(Vehicles left, Vehicles right)
		{
			return Utils.ValidatedEquals<NullVehicles>(left, right);
		}

		public static bool operator !=(Vehicles left, Vehicles right)
		{
			return !(left == right);
		}
	}

	internal class NullVehicles : Vehicles
	{
		public override IList<Car> Cars { get { throw this.NullAccess("Cars"); } }
	}

	public class Color
	{
		public virtual string Hue { get; set; }
		public virtual string Rgb { get; set; }
		public virtual ColorDescription Description { get; set; }

		public Color(XElement element)
		{
			Hue = element.Elements().Where(e => e.Name == "hue").Select(e => e.Value).SingleOrDefault();
			Rgb = element.Elements().Where(e => e.Name == "rgb").Select(e => e.Value).SingleOrDefault();
			Description = element.Elements().Where(e => e.Name == "description").Select(e => new ColorDescription(e)).SingleOrDefault() ?? new NullColorDescription();
		}

		public Color()
		{ }

		public static bool operator ==(Color left, Color right)
		{
			return Utils.ValidatedEquals<NullColor>(left, right);
		}

		public static bool operator !=(Color left, Color right)
		{
			return !(left == right);
		}
	}

	internal class NullColor : Color
	{
		public override string Hue { get { throw this.NullAccess("Hue"); } }
		public override string Rgb { get { throw this.NullAccess("Rgb"); } }
		public override ColorDescription Description { get { throw this.NullAccess("Description"); } }
	}

	public class Car
	{
		public virtual string Brand { get; set; }
		public virtual ManufacturerName Manufacturer { get; set; }
		public virtual Color Color { get; set; }

		public Car(XElement element)
		{
			Brand = element.Elements().Where(e => e.Name == "brand").Select(e => e.Value).SingleOrDefault();
			Manufacturer = element.Elements().Where(e => e.Name == "manufacturer").Select(e => new ManufacturerName(e)).SingleOrDefault() ?? new NullManufacturerName();
			Color = element.Elements().Where(e => e.Name == "color").Select(e => new Color(e)).SingleOrDefault() ?? new NullColor();
		}

		public Car()
		{ }

		public static bool operator ==(Car left, Car right)
		{
			return Utils.ValidatedEquals<NullCar>(left, right);
		}

		public static bool operator !=(Car left, Car right)
		{
			return !(left == right);
		}
	}

	internal class NullCar : Car
	{
		public override string Brand { get { throw this.NullAccess("Brand"); } }
		public override ManufacturerName Manufacturer { get { throw this.NullAccess("Manufacturer"); } }
		public override Color Color { get { throw this.NullAccess("Color"); } }
	}

	public class ColorDescription
	{
		public virtual string Text { get; set; }
		public virtual IList<string> SubDescriptions { get; set; }
		public virtual string LanguageAndScriptCode { get; set; }
		public virtual string DescriptionType { get; set; }

		public ColorDescription(XElement element)
		{
			Text = element.Elements().Where(e => e.Name == "text").Select(e => e.Value).SingleOrDefault();
			SubDescriptions = element.Elements().Where(e => e.Name == "SubDescription").Select(e => e.Value).ToList();
			LanguageAndScriptCode = element.Attributes().Where(e => e.Name == "LanguageAndScriptCode").Select(e => e.Value).SingleOrDefault();
			DescriptionType = element.Attributes().Where(e => e.Name == "descriptionType").Select(e => e.Value).SingleOrDefault();
		}

		public ColorDescription()
		{ }

		public static bool operator ==(ColorDescription left, ColorDescription right)
		{
			return Utils.ValidatedEquals<NullColorDescription>(left, right);
		}

		public static bool operator !=(ColorDescription left, ColorDescription right)
		{
			return !(left == right);
		}
	}

	internal class NullColorDescription : ColorDescription
	{
		public override string Text { get { throw this.NullAccess("Text"); } }
		public override IList<string> SubDescriptions { get { throw this.NullAccess("SubDescriptions"); } }
		public override string LanguageAndScriptCode { get { throw this.NullAccess("LanguageAndScriptCode"); } }
		public override string DescriptionType { get { throw this.NullAccess("DescriptionType"); } }
	}

	public class ManufacturerName
	{
		public override string ToString(){return Value;}
		public static implicit operator string(ManufacturerName obj){return obj.Value;}

		public virtual string Value { get; set; }
		public virtual string LanguageAndScriptCode { get; set; }
		public virtual string NameType { get; set; }

		public ManufacturerName(XElement element)
		{
			Value = element.Value;
			LanguageAndScriptCode = element.Attributes().Where(e => e.Name == "LanguageAndScriptCode").Select(e => e.Value).SingleOrDefault();
			NameType = element.Attributes().Where(e => e.Name == "nameType").Select(e => e.Value).SingleOrDefault();
		}

		public ManufacturerName()
		{ }

		public static bool operator ==(ManufacturerName left, ManufacturerName right)
		{
			return Utils.ValidatedEquals<NullManufacturerName>(left, right);
		}

		public static bool operator !=(ManufacturerName left, ManufacturerName right)
		{
			return !(left == right);
		}
	}

	internal class NullManufacturerName : ManufacturerName
	{
		public override string Value { get { throw this.NullAccess("Value"); } }
		public override string LanguageAndScriptCode { get { throw this.NullAccess("LanguageAndScriptCode"); } }
		public override string NameType { get { throw this.NullAccess("NameType"); } }
	}


	internal static class Utils
	{
		public static Exception NullAccess<T>(this T src, string name)
		{
			return new NullReferenceException("Property '" + name + "' was accessed from a null '" + 
				typeof(T).BaseType.Name + "' object");
		}

		public static bool ValidatedEquals<T>(object d1, object d2)
		{
			if (d1 is T || d2 is T) return (d1 == null || d2 == null);
			return ReferenceEquals(d1, d2);
		}
	}
}