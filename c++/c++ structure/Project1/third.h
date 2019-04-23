#pragma once
#include <iostream>
#include <math.h>
#include <cmath>

using namespace std;

struct point3
{
	char* data;//информационное поле
	point3 *left;//адрес левого поддерева
	point3 *right;//адрес правого поддерева
};

void Run(point3*p, int& k, char* s)
//обход слева направо
{
	if (p)
	{
		if (!strcmp(p->data, s))
		{
			k++;
		}
			Run(p->left, k , s);//переход к левому поддереву
		Run(p->right, k, s);//переход к правому поддереву
	}
}
int ch()
{
	cout << endl << "Введите n ";
	int n;
	cin >> n;
	while (n < 1)
	{
		cout << endl << "ошибка, введите снова";
		cin >> n;
	}
	return n;
}

void print_Tree(point3* p, int level)
{
	if (level== 0)
	{
		cout << endl << "дерево не создано! " << endl;
		cout << endl << "Нажмите 13, чтобы вызвать меню " << endl;
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
	cout <<endl << "Введите: ";
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
	cout << "Введите ключ: ";
	char s[50];
	cin >> s;
	Run(p, k, s);
	cout << endl << "СОВПАДЕНИЙ  " << k << endl;
	cout << endl << "Нажмите 13, чтобы вызвать меню " << endl;
}
point3* first(char* d)//формирование первого элемента дерева
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
	point3*p = root;//корень дерева
	point3*r = p;
	//флаг для проверки существования элемента d в дереве
	bool ok = false;
	while (p && !ok)
	{
		r = p;
		if (!strcmp(d, p->data))ok = true;//элемент уже существует
		else
			if (d<p->data)p = p->left;//пойти в левое поддерево
			else p = p->right;//пойти в правое поддерево
	}
	if (ok) return p;//найдено, не добавляем
					 //создаем узел
	point3* New_point = new point3();//выделили память
	New_point->data = d;
	New_point->left = 0;
	New_point->right = 0;
	// если d<r->key, то добавляем его в левое поддерево
	if (d<r->data)r->left = New_point;
	// если d>r->key, то добавляем его в правое поддерево
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

