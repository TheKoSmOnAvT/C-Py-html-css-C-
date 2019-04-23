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
	cout << endl << "Введите количество: ";
	cin >> n;
	while (n < 1)
	{
		cout << endl << "ошибка, введите снова";
		cin >> n;
	}
	cout << endl;
	point*beg;//указатель на первый элемент
	point*p, *r;//вспомогательные указатели
	beg = new(point);//выделяем память под первый элемент
	cout << "\n вводите: ";
	char s[50];
	cin >> s;
	beg->data= new char[strlen(s) + 1];//вводим значение информационного поля
	strcpy(beg->data,s);
	beg->next = 0;//обнуляем адресное поле
				  //strcpy(p->key,s);
	p = beg;
	for (int i = 0; i<n - 1; i++)
	{
		r = new(point);//создаем новый элемент
		cout << "\n вводите: ";
		char s[50];
		cin >> s;
		r->data = new char[strlen(s) + 1];
		strcpy(r->data, s);
		r->next = 0;
		p->next = r;//связываем p и r
					//ставим на r указатель p (последний элемент)
		p = r;
	}
	cout << endl << "Нажмите 13, чтобы вызвать меню " << endl;
	return beg;//возвращаем beg как результат функции

}

void print_list(point* beg, int n)
//печать списка
{
	if (n == 0)
	{
		cout << endl << "ошибка, список не сформирован " << endl;
		cout << endl << "Нажмите 13, чтобы вызвать меню " << endl;
		return;
	}
	cout << endl << "=============" << endl;
	point* p = beg;//начало списка
	while (p != 0)
	{
		cout << p->data << "\t";
		p = p->next;//переход к следующему элементу
	}
	cout << endl << "=============" << endl;
	cout << endl << "Нажмите 13, чтобы вызвать меню " << endl;
}

point* add_point(point* beg, int& razm)
//добавление элемента с номером k
{
	int k;
	if (razm == 0)//добавление в начало, если k=0
	{
		cout << endl << "ошибка, не сформирован." <<endl;
		cout << endl << "Нажмите 13, чтобы вызвать меню " << endl;
		return beg;
	}
	cout << endl << "введите цифру порядка, куда следует добавить номер: ";
	cin >> k;
	while (k < 1||k> razm+1 )
	{
		cout << endl << "ошибка, введите снова ";
		cin >> k;
		cout << endl;
	}
	k--;
	point*p = beg;//встали на первый элемент
	point*New = new(point);//создали новый элемент
	char s[50];
	cout << "Введите строку: "; cin >> s;
	New->data = new char[strlen(s) +1];
	strcpy(New->data,s);
	if (k == 0)//добавление в начало, если k=0
	{
		New->next = beg;
		beg = New;
		cout << endl << "Нажмите 13, чтобы вызвать меню " << endl;
		razm++;
		return beg;
	}
	for (int i = 0; i<k-1  && p != 0; i++)
		p = p->next;//проходим по списку до(k-1) элемента или до конца
	if (p != 0)//если k-й элемент существует
	{
		New->next = p->next;//связываем New и k-й элемент
		p->next = New;//связываем (k-1)элемент и New
	}
	cout << endl << "Нажмите 13, чтобы вызвать меню " << endl;
	razm++;
	return beg;
}