#pragma once
#include <iostream>
#include <math.h>
#include <cmath>

using namespace std;

struct point3
{
	char* data;//�������������� ����
	point3 *left;//����� ������ ���������
	point3 *right;//����� ������� ���������
};

void Run(point3*p, int& k, char* s)
//����� ����� �������
{
	if (p)
	{
		if (!strcmp(p->data, s))
		{
			k++;
		}
			Run(p->left, k , s);//������� � ������ ���������
		Run(p->right, k, s);//������� � ������� ���������
	}
}
int ch()
{
	cout << endl << "������� n ";
	int n;
	cin >> n;
	while (n < 1)
	{
		cout << endl << "������, ������� �����";
		cin >> n;
	}
	return n;
}

void print_Tree(point3* p, int level)
{
	if (level== 0)
	{
		cout << endl << "������ �� �������! " << endl;
		cout << endl << "������� 13, ����� ������� ���� " << endl;
		return;
	}
	if (p!=0)
	{
		print_Tree(p->left, level + 1);
		for (int i = 0; i< level; i++) cout << " ";
		cout << p->data << "\n " << "\n";
		print_Tree(p->right, level + 1);
	}
	
}

point3* Tree(int n, point3* p)
{
	point3*r;
	int nl, nr;
	if (n == 0) { p = NULL; return p; }

	nl = n / 2;
	nr = n - nl - 1;
	r = new point3;
	cout <<endl << "�������: ";
	char s[50];
	cin >> s;
    r->data = new char[strlen(s)+1];
	strcpy(r->data,s);
	r->left = Tree(nl, r->left);
	r->right = Tree(nr, r->right);
	return r;
}

void poisk(point3* p)
{
	int k = 0;
	cout << "������� ����: ";
	char s[50];
	cin >> s;
	Run(p, k, s);
	cout << endl << "����������  " << k << endl;
	cout << endl << "������� 13, ����� ������� ���� " << endl;
}
point3* first(char* d)//������������ ������� �������� ������
{
	point3* p = new point3;
	char s[50];
	p->data = d;
	p->left = 0;
	p->right = 0;
	return p;
}

point3* Add(point3*root, char* d, int&l)
{
	point3*p = root;//������ ������
	point3*r = p;
	//���� ��� �������� ������������� �������� d � ������
	bool ok = false;
	while (p && !ok)
	{
		r = p;
		if (!strcmp(d, p->data))ok = true;//������� ��� ����������
		else
			if (d<p->data)p = p->left;//����� � ����� ���������
			else p = p->right;//����� � ������ ���������
	}
	if (ok) return p;//�������, �� ���������
					 //������� ����
	point3* New_point = new point3();//�������� ������
	New_point->data = d;
	New_point->left = 0;
	New_point->right = 0;
	// ���� d<r->key, �� ��������� ��� � ����� ���������
	if (d<r->data)r->left = New_point;
	// ���� d>r->key, �� ��������� ��� � ������ ���������
	else r->right = New_point;
	l++;
	return New_point;
}

point3* New(point3*p, point3*&NewRoot, int& l)
{
	if (p)
	{
		New(p->left, NewRoot, l);
		Add(NewRoot, p->data, l);
		New(p->right, NewRoot, l);
	}
	return NewRoot;
}

