#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include <math.h>
#include <cmath>
#include "solo.h"
#include "second.h"
#include "third.h"
using namespace std;

int main()
{
	setlocale(0,"russian");

	point* a = new(point);
	point1 * a1 = new(point1);
	point3 * a2 = new(point3);
	point3 * a3 = new(point3);
	int q;
	int num = 0;
	int num1 = 0;
	int num2 = 0;
	int k = 0;
	int l=1;
	cout << endl <<"Нажмите 13, чтобы вызвать меню "<<endl;
	do
	{
		cout << '\n';
		cin >> q;
		switch (q)
		{
		case 1: a = make_list(num); break;
		case 2: print_list(a, num); break;
		case 3: a=add_point(a,num); break;
		case 4: a = d1(a,num); delete a; num = 0; cout << endl << "список удален " << endl << "Нажмите 13, чтобы вызвать меню " << endl; break;
		case 5: a1=make_list1(num1); break;
		case 6: print_list1(a1, num1); break;
		case 7: a1 = delet(a1, num1); break;
		case 8: a1 = d1(a1, num1); delete a1; num1 = 0; cout << endl << "список удален " << endl<<"Нажмите 13, чтобы вызвать меню " << endl; break;
		case 9: num2 =ch(); a2 = Tree(num2, a2); cout << endl << "Дерево создано. " << "Нажмите 13, чтобы вызвать меню " << endl; break;
		case 10: print_Tree(a2, num2); cout << endl << "Нажмите 13, чтобы вызвать меню " << endl; break;
		case 11: poisk(a2); break;
		case 12: cout << endl ; a3 = first(a2->data); a3 = New(a2, a3,l); print_Tree(a3,l); cout << endl << "Нажмите 13, чтобы вызвать меню " << endl;  break;
		case 13:
			cout << "\n--------->действия<---------\n";
			cout << "1.Сформировать однонаправленный список.\n";
			cout << "2.Печать однонаправленный список.\n";
			cout << "3.Добавить в однонаправленный список элемент с заданным номером.\n";
			cout << "4.Удалить однонаправленный список из памяти.\n";
			cout << "====================================\n";
			cout << "5.Сформировать двунаправленный список\n";
			cout << "6.Печать двунаправленный список.\n";
			cout << "7.Удалить из списка последний элемент с четным информационным полем.\n";
			cout << "8.Удалить двунаправленный список из памяти \n";
			cout << "====================================\n";
			cout << "9.Сформировать идеально сбалансированное бинарное дерево.\n";
			cout << "10.Печать дерева\n";
			cout << "11.Найти количество элементов с заданным ключом.\n";
			cout << "12.Преобразовать идеально сбалансированное дерево в дерево поиска.\n";
			cout << "====================================\n";
			cout << "13. Меню\n";
			cout << "0.Выход\n";
			break;
		}
	} while (q != 0);//выход
	system("pause");
}