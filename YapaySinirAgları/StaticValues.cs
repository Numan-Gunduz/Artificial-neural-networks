using NeuronDotNet.Core.Backpropagation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YapaySinirAgları
{
	public static class StaticValues
	{
		public static BackpropagationNetwork network;

		public static LinearLayer inputLayer;
	
		public static SigmoidLayer hiddenLayer;
	
		public static SigmoidLayer outputLayer;

	
		public static double[,] inputs =
		{
				{ 0, 0, 0, 0, 0},
				{ 0, 0, 0, 0, 0},
				{ 0, 0, 0, 0, 0},
				{ 0, 0, 0, 0, 0},
				{ 0, 0, 0, 0, 0},
				{ 0, 0, 0, 0, 0},
				{ 0, 0, 0, 0, 0}
		};

		public static int thirtyFive = 35;

		public static int zeros = 0;

		public static int ones = 1;

		public static int two = 2;
	
		public static int three = 3;

		public static int four = 4;

		public static int five = 5;
	
		public static int six = 6;

		public static string A = "A";

		public static string B = "B";

		public static string C = "C";
	
		public static string D = "D";

		public static string E = "E";
	
		public static string succesfull = "Tamamlandı";
	
		public static string defineYSAModel = "YSA Modelini Tanımlaya Bas!";
	
		public static string inputMatrixRead = "Giriş Matrisi Okundu";
	
		public static string classificationCompleted = "Sınıflandırma Tamamlandı!";

		public static string FullScreenOpen = "Tam Ekran Modunu Aç";

		public static string FullScreenClose = "Tam Ekran Modunu Kapat";

		public static string WouldYouOutput = "Çıkış yapmak istediğinize emin misiniz ? ";

		public static string Answer = "Soru";

	
	}
}
