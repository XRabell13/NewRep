#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <string.h>
#include <ctype.h>
#define  BUFSIZE   512
#define  BUFWORD   64

static int first_word(const char** s, char* w);
static int is_word(const char* s, const char* w);

int main(void) {
	char  line[BUFSIZE];
	char  word[BUFWORD];
	const char* ptr;

	FILE* fin = fopen("in.txt", "rt");
	if (fin == NULL)
		return 1;

	FILE* fout = fopen("out.txt", "wt+");

	while ((ptr = fgets(line, sizeof(line), fin)) != NULL) {
		if (!first_word(&ptr, word))
			continue;
		if (is_word(ptr, word))
			fputs(line, fout);
	}
	fclose(fin);

	fflush(fout);
	fclose(fout);

	return 0;
}

//выделяем(копируем) первое слово в строке
static int first_word(const char** s, char* w) {
	const char* p = *s;
	char* t = w;
	while (*p && !isalpha(*p))
		++p;
	while (isalpha(*p) && (w - t < BUFWORD))
		* w++ = *p++;
	*w = '\0';
	*s = p;
	return (w != t);
}

// проверяем слова в строке(не подстроки)
static int is_word(const char* s, const char* w) {
	const char* t = s;
	const size_t n = strlen(w);
	while ((s = strstr(s, w)) != NULL) {
		if (((t == s) || !isalpha(*(s - 1)) && !isalpha(*(s + n))))
			return 1;
		s += n;
	}
	return 0;
}