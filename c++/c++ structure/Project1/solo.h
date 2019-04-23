#pragma once
#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include <math.h>
#include <cmath>
using namespace std;

struct point
{
	char* data;
	point* next;
};

point* d1(point* beg, int n)
{
	if (n == 0)
	{
		return 0;
	}
	point* p = beg;
	for (int i = 0; i < n - 1, p->next != 0; i++)
	{
		p = p->next;
		point* z = beg;
		beg = beg->next;
		delete z;
	}
	return beg;
}

point* make_list(int& n)
{
	cout << endl << "������� ����������: ";
	cin >> n;
	while (n < 1)
	{
		cout << endl << "������, ������� �����";
		cin >> n;
	}
	cout << endl;
	point*beg;//��������� �� ������ �������
	point*p, *r;//��������������� ���������
	beg = new(point);//�������� ������ ��� ������ �������
	cout << "\n �������: ";
	char s[50];
	cin >> s;
	beg->data= new char[strlen(s) + 1];//������ �������� ��������������� ����
	strcpy(beg->data,s);
	beg->next = 0;//�������� �������� ����
				  //strcpy(p->key,s);
	p = beg;
	for (int i = 0; i<n - 1; i++)
	{
		r = new(point);//������� ����� �������
		cout << "\n �������: ";
		char s[50];
		cin >> s;
		r->data = new char[strlen(s) + 1];
		strcpy(r->data, s);
		r->next = 0;
		p->next = r;//��������� p � r
					//������ �� r ��������� p (��������� �������)
		p = r;
	}
	cout << endl << "������� 13, ����� ������� ���� " << endl;
	return beg;//���������� beg ��� ��������� �������

}

void print_list(point* beg, int n)
//������ ������
{
	if (n == 0)
	{
		cout << endl << "������, ������ �� ����������� " << endl;
		cout << endl << "������� 13, ����� ������� ���� " << endl;
		return;
	}
	cout << endl << "=============" << endl;
	point* p = beg;//������ ������
	while (p != 0)
	{
		cout << p->data << "\t";
		p = p->next;//������� � ���������� ��������
	}
	cout << endl << "=============" << endl;
	cout << endl << "������� 13, ����� ������� ���� " << endl;
}

point* add_point(point* beg, int& razm)
//���������� �������� � ������� k
{
	int k;
	if (razm == 0)//���������� � ������, ���� k=0
	{
		cout << endl << "������, �� �����������." <<endl;
		cout << endl << "������� 13, ����� ������� ���� " << endl;
		return beg;
	}
	cout << endl << "������� ����� �������, ���� ������� �������� �����: ";
	cin >> k;
	while (k < 1||k> razm+1 )
	{
		cout << endl << "������, ������� ����� ";
		cin >> k;
		cout << endl;
	}
	k--;
	point*p = beg;//������ �� ������ �������
	point*New = new(point);//������� ����� �������
	char s[50];
	cout << "������� ������: "; cin >> s;
	New->data = new char[strlen(s) +1];
	strcpy(New->data,s);
	if (k == 0)//���������� � ������, ���� k=0
	{
		New->next = beg;
		beg = New;
		cout << endl << "������� 13, ����� ������� ���� " << endl;
		razm++;
		return beg;
	}
	for (int i = 0; i<k-1  && p != 0; i++)
		p = p->next;//�������� �� ������ ��(k-1) �������� ��� �� �����
	if (p != 0)//���� k-� ������� ����������
	{
		New->next = p->next;//��������� New � k-� �������
		p->next = New;//��������� (k-1)������� � New
	}
	cout << endl << "������� 13, ����� ������� ���� " << endl;
	razm++;
	return beg;
}