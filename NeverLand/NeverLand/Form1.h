#pragma once
#include "WorldView.h"
namespace NeverLand {

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
	private: System::Windows::Forms::Button^  button_test;
	protected: 

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
			this->button_test = (gcnew System::Windows::Forms::Button());
			this->SuspendLayout();
			// 
			// button_test
			// 
			this->button_test->Location = System::Drawing::Point(12, 199);
			this->button_test->Name = L"button_test";
			this->button_test->Size = System::Drawing::Size(72, 44);
			this->button_test->TabIndex = 0;
			this->button_test->Text = L"test";
			this->button_test->UseVisualStyleBackColor = true;
			this->button_test->Click += gcnew System::EventHandler(this, &Form1::button_test_Click);
			// 
			// Form1
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(8, 16);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(282, 255);
			this->Controls->Add(this->button_test);
			this->Name = L"Form1";
			this->Text = L"Entry";
			this->ResumeLayout(false);

		}
#pragma endregion
	private: System::Void button_test_Click(System::Object^  sender, System::EventArgs^  e) 
			 {
				 WorldView^ world_view= gcnew WorldView();
				 world_view->Show();
			 }
	};
}

