#include <cstdlib>
#include <ctime>
#include <Random.h>

Random::Random()
{
	::srand(static_cast<unsigned>(::time(NULL)));
}

Random::~Random()
{
}

bool Random::nextBool() const
{
	return (1 == (::rand() % 2));
}

int Random::nextInt() const
{
	return ::rand();
}

int Random::nextInt(int max) const
{
	return ::rand() % max;
}

int Random::nextInt(int min, int max) const
{
	return min +::rand() % (max - min + 1);
}

