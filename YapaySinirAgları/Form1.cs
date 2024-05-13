using NeuronDotNet.Core;
using NeuronDotNet.Core.Backpropagation;
using System;
using System.Drawing;
using System.Windows.Forms;
namespace YapaySinirAgları
{

	public partial class Form1 : Form
	{

		TrainingSet trainingSet = new TrainingSet(35, 5);

		public Form1()
		{
			InitializeComponent();
		}

		private void button31_Click(object sender, EventArgs e)
		{
			if (((Button)sender).BackColor == Color.Black)
			{
				((Button)sender).BackColor = SystemColors.Control;
				return;
			}
			  ((Button)sender).BackColor = Color.Black;
		}

		private void button31_DragOver(object sender, DragEventArgs e)
		{
			button31_Click(sender, e);
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			foreach (Button item in panelMatrisContainer.Controls)
			{
				if (item is Button)
					item.BackColor = SystemColors.Control;
			}
		}
		private void btnTanımla_Click(object sender, EventArgs e)
		{
			Tanimla();
		}

		private void Form1Load (object sender, EventArgs e)
		{
			LoadData();
		}

		private void btnEgit_Click(object sender, EventArgs e)
		{
			VeriKümesiYükleVeGirişÇıkışSonuçlarıBelirle();
			double errorRate = Convert.ToDouble(txtErrorRate.Text);
			StaticValues.network.SetLearningRate(errorRate);
			
			StaticValues.network.SetLearningRate(Convert.ToDouble(txtLearningRate.Text));
			StaticValues.network.Learn(trainingSet, Convert.ToInt32(txtIteration.Text));
			bilgiler.Items.Insert(StaticValues.zeros, StaticValues.succesfull);
			txtLearningRate.Enabled = false;
			txtIteration.Enabled = false;
			lblError.Text += StaticValues.network.MeanSquaredError.ToString();
			txtLearning.Text += StaticValues.network.InputLayer.LearningRate.ToString();
			btnEgit.Enabled = false;
			btnTanımla.Enabled = true;
		}



		public double[] GetInputs()
		{

			foreach (Control item in panelMatrisContainer.Controls)
			{

				if (item is Button)
				{
					int index = Convert.ToInt32(((Button)item).Tag.ToString());
					if (item.BackColor == Color.Black)
					{
						// Gelen index numarasına göre  0 değerleri atanıyor .. 
						if (index <= 4)
							StaticValues.inputs[StaticValues.zeros, index] = StaticValues.ones;
						else if (index <= 9)
							StaticValues.inputs[StaticValues.ones, index % StaticValues.five] = StaticValues.ones;
						else if (index <= 14)
							StaticValues.inputs[StaticValues.two, index % StaticValues.five] = StaticValues.ones;
						else if (index <= 19)
							StaticValues.inputs[StaticValues.three, index % StaticValues.five] = StaticValues.ones;
						else if (index <= 24)
							StaticValues.inputs[StaticValues.four, index % StaticValues.five] = StaticValues.ones;
						else if (index <= 29)
							StaticValues.inputs[StaticValues.five, index % StaticValues.five] = StaticValues.ones;
						else if (index <= 34)
							StaticValues.inputs[StaticValues.six, index % StaticValues.five] = StaticValues.ones;
					}
					index++;
				}

			}
			double[] response = new double[35];
			Buffer.BlockCopy(StaticValues.inputs, 0, response, 0, StaticValues.thirtyFive * sizeof(double));
			return response;

		}
		public void LoadData()
		{
			bilgiler.Items.Insert(0, StaticValues.defineYSAModel);
			StaticValues.inputLayer = new LinearLayer(StaticValues.thirtyFive);
			StaticValues.hiddenLayer = new SigmoidLayer(StaticValues.thirtyFive);
			StaticValues.outputLayer = new SigmoidLayer(StaticValues.five);
			BackpropagationConnector connector = new BackpropagationConnector(StaticValues.inputLayer, StaticValues.hiddenLayer);
			BackpropagationConnector connector2 = new BackpropagationConnector(StaticValues.hiddenLayer, StaticValues.outputLayer);
			StaticValues.network = new BackpropagationNetwork(StaticValues.inputLayer, StaticValues.outputLayer);
			StaticValues.network.Initialize();
		}
		public void VeriKümesiYükleVeGirişÇıkışSonuçlarıBelirle()
		{

			trainingSet.Add(new TrainingSample(MyDataSet.A, new double[5]
				{ StaticValues.ones, StaticValues.zeros, StaticValues.zeros, StaticValues.zeros, StaticValues.zeros }));
			bilgiler.Items.Insert(StaticValues.zeros, StaticValues.A);
			trainingSet.Add(new TrainingSample(MyDataSet.B, new double[5]
				{ StaticValues.zeros, StaticValues.ones, StaticValues.zeros, StaticValues.zeros, StaticValues.zeros }));
			bilgiler.Items.Insert(StaticValues.zeros, StaticValues.B);
			trainingSet.Add(new TrainingSample(MyDataSet.C, new double[5]
				{ StaticValues.zeros, StaticValues.zeros, StaticValues.ones, StaticValues.zeros, StaticValues.zeros }));
			bilgiler.Items.Insert(StaticValues.zeros, StaticValues.C);
			trainingSet.Add(new TrainingSample(MyDataSet.D, new double[5]
			{ StaticValues.zeros, StaticValues.zeros, StaticValues.zeros, StaticValues.ones, StaticValues.zeros }));
			bilgiler.Items.Insert(StaticValues.zeros, StaticValues.D);
			trainingSet.Add(new TrainingSample(MyDataSet.E, new double[5]
				{ StaticValues.zeros, StaticValues.zeros, StaticValues.zeros, StaticValues.zeros, StaticValues.ones }));
			bilgiler.Items.Insert(StaticValues.zeros, StaticValues.E);
		}
		public void Tanimla()
		{
			if (listBoxOutputs.Items.Count > 0)
			{
				listBoxOutputs.Items.Clear();
				txtMatris.Clear();
			}
			double[] inputMatris = GetInputs();
			bilgiler.Items.Insert(0, StaticValues.inputMatrixRead);

			double[] output = StaticValues.network.Run(inputMatris);
			int index = 0;
			foreach (double item in output)
			{
				string letter = Convert.ToChar(65 + index).ToString(); // ASCII kodundan harfi elde etme
				listBoxOutputs.Items.Add(letter + "-) " + item.ToString() + "\n");
				index++;
			}
			bilgiler.Items.Insert(0, StaticValues.classificationCompleted);

			index = 1;
			foreach (var item in inputMatris)
			{
				txtMatris.Text += (item.ToString() + "    ");
				if (index % StaticValues.five == StaticValues.zeros)
				{
					txtMatris.Text += "\n";
				}
				index++;
			}

			txtMatris.SelectAll();
			txtMatris.SelectionAlignment = HorizontalAlignment.Center;
			txtMatris.DeselectAll();
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}
	}
}
