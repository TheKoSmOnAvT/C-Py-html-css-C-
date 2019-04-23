#pragma once
#include <iostream>
#include <math.h>
#include <cmath>

using namespace std;

struct point1
{
	int key;//�������� ���� � ������������ ������
	point1 *next;//��������� �� ��������� �������
	point1 *pred;//��������� �� ���������� �������
};

point1* make_point1()
//�������� ������ ��������
{
	int k;
	point1*p = new(point1);
	p->next = 0; p->pred = 0;//�������� ���������
	cout << "\n�������:";
	cin >> k;
	p->key=k;
	return p;
}

point1* d1(point1* beg,int n)
{
	if (n == 0)
	{
		return 0;
	}
	point1* p = beg;
	for (int i = 0; i < n - 1, p->next != 0; i++)
	{
		p = p->next;
		point1* z = beg;
		beg = beg->next;
		delete z;
	}
	return beg;
}

point1*make_list1(int& n)
//�������� ������
{
	cout << "\n������� n: ";
	cin >> n;
	while (n < 1)
	{
		cout << endl << "������, ������� �����";
		cin >> n;
	}
	point1 *beg;
	beg = make_point1();//������� ������ �������
	point1* p = beg;
	for (int i = 1; i<n; i++)
	{
		point1*r = make_point1();
		p->next = r;
		r->pred = p;
		p = r;

	}
	cout << endl << "������� 13, ����� ������� ���� " << endl;
	return beg;
}
void print_list1(point1* beg, int n)
//������ ������1
{
	if (n == 0)
	{
		cout << endl << "������, ������ �� ����������� " << endl;
		cout << endl << "������� 13, ����� ������� ���� " << endl;
		return;
	}
	cout << endl << "=============" << endl;
	point1* p = beg;
	for (int i = 0; i < n; i++)
	{
			cout << p->key<< "\t";
			p = p->next;
	}
	cout << endl << "=============" << endl;
	cout << endl << "������� 13, ����� ������� ���� " << endl;

}
point1*delet(point1* beg, int&n)
{
	if (n == NULL) { cout << "\n������ ����\n"<<"������� 13, ����� ������� ����"<<endl; return 0; }
	point1* p = beg;

	if ((p->key) % 2 == 0)//�������� ������� ��������
	{
		beg = beg->next;
		delete p;
		n--;
		cout <<"������� ������. " <<endl << "������� 13, ����� ������� ����" << endl;
		return beg;
	}
	
	for (int i = 0; i < n-1, p->next!=0; i++)
	{
		p = p->next;
		if ((p->key)%2==0)
		{
			point1* r = p->next;
			point1* q = p->pred;
			q->next = r;
			r->pred = q;
			delete p;
			n--;
			cout << endl << "�������� �������" << endl << "������� 13, ����� ������� ����" << endl;
			return beg;
		}
	}
	cout << endl << "������ ��������� ���! " << endl << "������� 13, ����� ������� ����" << endl;
	return beg;
}