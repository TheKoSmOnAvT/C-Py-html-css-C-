#pragma once
#include <iostream>
#include <math.h>
#include <cmath>

using namespace std;

struct point1
{
	int key;//адресное поле – динамическая строка
	point1 *next;//указатель на следующий элемент
	point1 *pred;//указатель на предыдущий элемент
};

point1* make_point1()
//создание одного элемента
{
	int k;
	point1*p = new(point1);
	p->next = 0; p->pred = 0;//обнуляем указатели
	cout << "\nВведите:";
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
//создание списка
{
	cout << "\nВведите n: ";
	cin >> n;
	while (n < 1)
	{
		cout << endl << "ошибка, введите снова";
		cin >> n;
	}
	point1 *beg;
	beg = make_point1();//создаем первый элемент
	point1* p = beg;
	for (int i = 1; i<n; i++)
	{
		point1*r = make_point1();
		p->next = r;
		r->pred = p;
		p = r;

	}
	cout << endl << "Нажмите 13, чтобы вызвать меню " << endl;
	return beg;
}
void print_list1(point1* beg, int n)
//печать списка1
{
	if (n == 0)
	{
		cout << endl << "ошибка, список не сформирован " << endl;
		cout << endl << "Нажмите 13, чтобы вызвать меню " << endl;
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
	cout << endl << "Нажмите 13, чтобы вызвать меню " << endl;

}
point1*delet(point1* beg, int&n)
{
	if (n == NULL) { cout << "\nСписок пуст\n"<<"введите 13, чтобы вывести меню"<<endl; return 0; }
	point1* p = beg;

	if ((p->key) % 2 == 0)//удаление первого элемента
	{
		beg = beg->next;
		delete p;
		n--;
		cout <<"Элемент удален. " <<endl << "введите 13, чтобы вывести меню" << endl;
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
			cout << endl << "Элементы удалены" << endl << "введите 13, чтобы вывести меню" << endl;
			return beg;
		}
	}
	cout << endl << "Четных элементов нет! " << endl << "введите 13, чтобы вывести меню" << endl;
	return beg;
}