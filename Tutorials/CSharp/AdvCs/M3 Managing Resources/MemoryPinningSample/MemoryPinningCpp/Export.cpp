#include <stdio.h>
#include <thread>
#include <chrono>

using namespace std;
using namespace chrono;

void Fill(char* ptr, int value, int size)
{
	memset(ptr, value, size);
}

void FillAsync(char* ptr, int value, int size)
{
	thread _thread([=]()
	{
		this_thread::sleep_for(chrono::milliseconds(1000));

		memset(ptr, value, size);

		printf("\nUnmanged completed writing!\n");
	});
	_thread.join();
}
