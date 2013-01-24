#pragma once

namespace ftp355 {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	/// <summary>
	/// Summary for Form1
	/// </summary>
	public ref class Form1 : public System::Windows::Forms::Form
	{
	public:
		Form1(void)
		{
			InitializeComponent();
			//
			//TODO: Add the constructor code here
			//
		}

	protected:
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		~Form1()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::TextBox^  textBoxServer;
	protected: 
	private: System::Windows::Forms::TextBox^  textBoxUN;
	private: System::Windows::Forms::TextBox^  textBoxPW;
	private: System::Windows::Forms::Button^  buttonSubmit;
	private: System::Windows::Forms::Label^  labelServer;
	private: System::Windows::Forms::Label^  labelUN;
	private: System::Windows::Forms::Label^  labelPW;

	private:
		/// <summary>
		/// Required designer variable.
		/// </summary>
		System::ComponentModel::Container ^components;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		void InitializeComponent(void)
		{
			this->textBoxServer = (gcnew System::Windows::Forms::TextBox());
			this->textBoxUN = (gcnew System::Windows::Forms::TextBox());
			this->textBoxPW = (gcnew System::Windows::Forms::TextBox());
			this->buttonSubmit = (gcnew System::Windows::Forms::Button());
			this->labelServer = (gcnew System::Windows::Forms::Label());
			this->labelUN = (gcnew System::Windows::Forms::Label());
			this->labelPW = (gcnew System::Windows::Forms::Label());
			this->SuspendLayout();
			// 
			// textBoxServer
			// 
			this->textBoxServer->Location = System::Drawing::Point(63, 27);
			this->textBoxServer->Name = L"textBoxServer";
			this->textBoxServer->Size = System::Drawing::Size(100, 20);
			this->textBoxServer->TabIndex = 0;
			this->textBoxServer->Text = L"drwestfall.info";
			// 
			// textBoxUN
			// 
			this->textBoxUN->Location = System::Drawing::Point(63, 75);
			this->textBoxUN->Name = L"textBoxUN";
			this->textBoxUN->Size = System::Drawing::Size(100, 20);
			this->textBoxUN->TabIndex = 1;
			this->textBoxUN->Text = L"project01";
			// 
			// textBoxPW
			// 
			this->textBoxPW->Location = System::Drawing::Point(63, 124);
			this->textBoxPW->Name = L"textBoxPW";
			this->textBoxPW->Size = System::Drawing::Size(100, 20);
			this->textBoxPW->TabIndex = 2;
			this->textBoxPW->Text = L"csci355";
			// 
			// buttonSubmit
			// 
			this->buttonSubmit->Location = System::Drawing::Point(63, 156);
			this->buttonSubmit->Name = L"buttonSubmit";
			this->buttonSubmit->Size = System::Drawing::Size(100, 23);
			this->buttonSubmit->TabIndex = 3;
			this->buttonSubmit->Text = L"Test Connection";
			this->buttonSubmit->UseVisualStyleBackColor = true;
			// 
			// labelServer
			// 
			this->labelServer->AutoSize = true;
			this->labelServer->Location = System::Drawing::Point(60, 11);
			this->labelServer->Name = L"labelServer";
			this->labelServer->Size = System::Drawing::Size(72, 13);
			this->labelServer->TabIndex = 4;
			this->labelServer->Text = L"Server Name:";
			this->labelServer->Click += gcnew System::EventHandler(this, &Form1::labelServer_Click);
			// 
			// labelUN
			// 
			this->labelUN->AutoSize = true;
			this->labelUN->Location = System::Drawing::Point(60, 59);
			this->labelUN->Name = L"labelUN";
			this->labelUN->Size = System::Drawing::Size(58, 13);
			this->labelUN->TabIndex = 5;
			this->labelUN->Text = L"Username:";
			// 
			// labelPW
			// 
			this->labelPW->AutoSize = true;
			this->labelPW->Location = System::Drawing::Point(60, 108);
			this->labelPW->Name = L"labelPW";
			this->labelPW->Size = System::Drawing::Size(56, 13);
			this->labelPW->TabIndex = 6;
			this->labelPW->Text = L"Password:";
			// 
			// Form1
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(232, 191);
			this->Controls->Add(this->labelPW);
			this->Controls->Add(this->labelUN);
			this->Controls->Add(this->labelServer);
			this->Controls->Add(this->buttonSubmit);
			this->Controls->Add(this->textBoxPW);
			this->Controls->Add(this->textBoxUN);
			this->Controls->Add(this->textBoxServer);
			this->Name = L"Form1";
			this->Text = L"The Fantastic 4 FTP";
			this->Load += gcnew System::EventHandler(this, &Form1::Form1_Load);
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion
	private: System::Void Form1_Load(System::Object^  sender, System::EventArgs^  e) {
			 }
	private: System::Void labelServer_Click(System::Object^  sender, System::EventArgs^  e) {
			 }
};
}

