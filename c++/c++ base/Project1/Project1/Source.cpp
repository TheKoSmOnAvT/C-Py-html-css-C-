#define _CRT_SECURE_NO_WARNINGS
#include <math.h>
#include <stdio.h>
#include <iostream>
#include <cmath>
#include <ctime>
#include <windows.h>
#include <string>
#include <string.h>
#include <cstdlib>
#include <fstream>


using namespace std;

struct Point
{
	string Name;
	string Soname;
	string Otch;
	string Date;
	string Address;
};

//���
Point MakePoint() //������� ���������
{
	Point p;
	string Date[20] = {"12.11.1990","10.02.1986", "05.10.1988", "30.05.1999", "29.11.1960", "22.03.1974", "13.02.1975", "14.08.1994", "21.03.2010", "19.05.1991", "15.08.2008", "13.05.2005", "14.06.1966", "21.11.1979", "01.10.1975", "02.03.1995", "08.07.1997", "05.01.2001", "28.04.2000", "25.03.1989", };
	string Otch[20] = {"���������","�����", "���������", "���������", "�����", "����������", "���������", "�������", "�����������", "�������", "�����������", "��������������", "���������", "�������", "�����", "����������", "�����������", "���������", "��������", "�������������", };
	string SoName[20] = {"�������","��������","�������", "������", "������", "�����", "������", "�������", "������", "��������", "��������", "�����", "�������", "���������", "�������", "��������", "�����", "��������", "�����" , "�����"};
	string Name[20] = { "����", "����", "�����", "�����", "���������", "����", "����", "����", "������", "������", "������", "����", "��������", "�������", "��", "�����", "���", "����", "�����", "������"};
		int a = rand() % 29;
		int d = rand() % 19;
		int n = rand() % 19;
		int s = rand() % 19;
		int o = rand() % 19;
	string name = Name[n];
	string Soame = SoName[s];
	string otch = Otch[o];
	string date = Date[d];
	p.Name = name;
	p.Soname = Soame;
	p.Otch = otch;
	p.Date = date;
	return p;
}
Point MakePointHand() //������� ���������
{
	Point p;
	string n, s, o, d, a;
	cout << endl << "������� ��� ��������: ";
	cin >>n;
	cout << endl << "������� ������� ��������: ";
	cin >> s;
	cout << endl << "������� �������� ��������: ";
	cin >> o;
	cout << endl << "������� ���� ��������: ";
	cin >> d;
	cout << endl << "������� ����� ��������(����� �������� ��������): ";
	cin >> a;
	p.Name = n;
	p.Soname = s;
	p.Otch = o;
	p.Date = d;
	p.Address = a;
	return p;
}

//����� ������� 
int razm()
{
	int n;
	do
	{
		cout << "������� ���-�� �����: ";
		cin >> n;
	} while (n <= 0); 
	return n;
}

//��� ���
int GetHashCode11(string s)
{
	int sum = 0;
	for (int i = 0; i < s.length(); i++)
	{
		cout << endl << "=== " << s[i] << endl;
		system("pause");
		sum += abs(s[i]);
		cout << endl << "=== " << s[i]<<endl;
		system("pause");
	}
	return sum;
}
int GetHashCode(string s, int size)
{
	double y = 1;
	return modf((GetHashCode11(s)*0.61), &y)*(size);
}

//�������� ��� ������� � �� ������
Point* FormPoint(int n)
{
	ifstream in("adress.txt");
	Point* p = new Point[n];
	for (int i = 0; i< n; i++)
	{
		p[i] = MakePoint();
		string s = "";
		in >> s;
		if (in.eof())
			break;
		p[i].Address = s;
	}
	in.close();
	return p;
}
string *FormHashTable(Point* p, int &size, int n, int &coll)
{
	if (n >= size * 0.7)
	{
		while (n >= size * 0.7)
		{
			size = size * 2;
		}
	}
	string *ht = new string[size];
	for (int i = 0; i < size; i++)
	{
		ht[i] = " ";
	}
	coll = 0;
	for (int i = 0; i < n; i++)
	{
		int code = GetHashCode(p[i].Address,size);
		if (ht[code] == " ")
		{
			ht[code] += p[i].Name + " " + p[i].Soname + " "+ p[i].Otch +" " + p[i].Date + " " + p[i].Address;
		}
		else
		{
			coll++;
			while (ht[code] != " ")
			{
				code++;
				if (code == size)
					code = 0;
			}
			ht[code] += p[i].Name + " " + p[i].Soname + " " + p[i].Otch + " " + p[i].Date + " " + p[i].Address;
		}
	}
	return ht;
}
void PrintHashTable(string *ht, int size)
{
	for (int i = 0; i < size; i++)
	{
		cout << i + 1 << ".";
		if (ht[i] == " ")
			cout << " ������ ������!" << endl;
		else
			cout << ht[i] << endl;
	}
}

// ���������� ��������� 
Point* FormPoint2(Point *p, int & n)
{
	Point *p2 = new Point[n + 1];
	int i = 0;
	for (; i < n; i++)
	{
		p2[i] = p[i];
	}
	n++;
	p2[i] = MakePointHand(); //
	return p2;
}
string *Adds(Point *&p, int &size, int &n, int& coll)
    {
	int d = n + 1;
	if (d >= size * 0.7)
	{
		size = size * 2;
		p = FormPoint2(p, n);
		string *ht1 = FormHashTable(p, size, n, coll);
		return ht1;
	}
	else
	{
		p = FormPoint2(p, n);
		string *ht1 = FormHashTable(p, size, n, coll);
		return ht1;
	}

	}


//���������� - �������� 
void Save(string *ht, int n)
{
	ofstream out;
	out.open("Ht.txt", ofstream::out);
	if (out.is_open())
	{
		for (int i = 0; i < n; i++)
		{
			if (ht[i] != " ")
				out << ht[i] << endl;
		}
	}
	out.close();
}
void Open()
{
	Point p;
	ifstream in("Ht.txt");
	int j = 0;
	if (in.is_open())
	{
		do
		{
			in >> p.Name;
			in >> p.Soname;
			in >> p.Otch;
			in >> p.Date;
			in >> p.Address;
			j++;
			if (in.eof())
			{
				break;
			}
			cout << endl << p.Name << " " << p.Soname << " " << p.Otch << " " << p.Date << " " << p.Address;
		} while (true);
	}

	if (j == 1)
	{
		cout << "�����!" << endl;
	}
	in.close();

}

//������� � ������ �� ����� 
string FoundStreet(string str)
{
	string s = "";
	int i = 0;
	int number = 0;
	while (number != 5)
	{
		while (str[i] != ' ')
			i++;
		while (str[i] == ' ')
			i++;
		number++;
	} 

	while (str[i] != '\0')
	{
		s = s +  str[i];
		i++;
	}
	return s;
}

//���� ��� ���
bool YoN(string *ht, int size, string adr)
{
	string s;
	for (int i = 0; i < size; i++)
	{
		if (ht[i] != " ")
		{
			s = FoundStreet(ht[i]);
			if (s == adr)
			{
				return 1;
			}
		}
	}
	return 0;
}

//���� ��� �����
string Searchstr(string *ht, int size)
{
	string s;
	do
	{
		cout << "������� �����: ";
		std::cin >> s;
		if (YoN(ht, size, s) == 0)
		{
			cout << endl <<"������ ���!" << endl;
			string h = " ";
			return h;
		}
	} while (YoN(ht, size, s) != 1);

	return s;
}

//��������)
void Delete(string *ht, int size)
{
	string s = Searchstr(ht, size);
	if (s == " ")
	{
		return;
	}
	int code = GetHashCode(s, size); 
	for (code; FoundStreet(ht[code]) != s; code++)
	{
		if (code == size)
		{
			code = 0;
		}
	}
	cout << endl << "������� �����\n";
	ht[code] = " ";
	return;
}

void POISK(string *ht, int size)
{
	string s = Searchstr(ht, size);
	if (s == " ")
	{
		return;
	}
	int code = GetHashCode(s, size);
	for (code; FoundStreet(ht[code]) != s; code++)
	{
		if (code == size)
		{
			code = 0;
		}
	}
	cout <<endl << "===== "<< code + 1 << ")" << ht[code] << endl;
	return;
}
int main()
{
	srand(time(NULL));
	setlocale(0, "rus");
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	int num; // switch
	int size; //������
	int n=0; //��� �����
	Point *p = new (Point);
	string *ht = NULL; 
	int SumCol = 0; //collusion

	cout << "������� 9 ��� ������ ����" << endl;
	do
	{
		cin >> num;
		switch (num)
		{
		case 1:size = 100; SumCol = 0; n = razm(); p = FormPoint(n); ht = FormHashTable(p, size, n, SumCol);  cout << endl << "������� ������������, ������� 9, ����� ������� ����" << endl; break;
		case 2:if (n == 0) { cout << endl << "������, ������� �� ������������,������� 9, ����� ������� ����";break;} PrintHashTable(ht, size); cout << endl << "������� 9, ����� ������� ����" << endl; break;
		case 3:if (n == 0) { cout << endl << "������, ������� �� ������������,������� 9, ����� ������� ����";break;} ht = Adds(p,size,n,SumCol); cout << endl << "������� 9, ����� ������� ����" << endl; break;
		case 4:if (n == 0) { cout << endl << "������, ������� �� ������������,������� 9, ����� ������� ����"; break; } Delete(ht,size); cout << endl << "������� 9, ����� ������� ����" << endl; break;
		case 5:if (n == 0) { cout << endl << "������, ������� �� ������������,������� 9, ����� ������� ����"; break; } POISK(ht, size); cout << endl; cout << endl << "������� 9, ����� ������� ����" << endl;  break;
		case 6:if (n == 0) { cout << endl << "������, ������� �� ������������,������� 9, ����� ������� ����";break;} cout << endl << "���������� ��������: " << SumCol << endl << "������� 9, ����� ������� ����" << endl; break;
		case 7:if (n == 0) { cout << endl << "������, ������� �� ������������,������� 9, ����� ������� ����"; break; } Save(ht,size); cout << endl << "������� 9, ����� ������� ����" << endl; break;
		case 8: Open(); cout << endl << "������� 9, ����� ������� ����" << endl; break;
		case 9:
		{
			cout << "\n1.������������ �������" << endl;
			cout << "2.������ ���-�������" << endl;
			cout << "3.�������� �������" << endl; 
			cout << "4.������� �������" << endl; 
			cout << "5.����� ��������" << endl;
			cout << "6.������� ���-�� ��������" << endl; 
			cout << "7.��������� ������ � ����" << endl;
			cout << "8.��������� ������ �� �����" << endl; 
			cout << "9.����� ����" << endl; 
			cout << "0.�����" << endl; 
			break;
		}
		}
	} while (num != 0); 

	cout << endl;
	system("pause");
}