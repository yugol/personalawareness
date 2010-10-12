#include <cstdlib>
#include <ctime>
#include <Random.h>

Random::Random()
{
	srand(time(NULL) + rand());
}

Random::~Random()
{
}

bool Random::nextBool() const
{
	return rand() % 2;
}

int Random::nextInt() const
{
	return rand();
}

int Random::nextInt(int max) const
{
	return rand() % max;
}

int Random::nextInt(int min, int max) const
{
	return min + rand() % (max - min + 1);
}

