#include <stdio.h>
#include <stdlib.h>
#include <string.h>

//wektor "trzymajacy" liczby (typu double)
typedef struct lineVector {
    double * data;
    double sum;
    size_t size;
} lvector;

//wektor "trzymajacy" wektory linii (czyli po prostu linie)
typedef struct fileVector {
    lvector * line_count;
    size_t size;
} fvector;

//inicjalizowanie wektora
fvector initialize_f() {
    fvector vector;
    vector.size = 0;
    vector.line_count = malloc(sizeof(lvector));

    return vector;
}

//wczytanie danych z pliku
void load_data_moje(fvector * v) {
    //inicjalizowanie zmiennych
    FILE * file;     
    lvector new_line_help;   
    int c = 'a'; //cokolwiek co nie jest EOF ani '\n'       
    size_t line_iterator;
    size_t vector_iterator = 0;

    //otwarcie pliku, nie sprawdzam czy sie udalo, pewnie powinienem
    file = fopen("liczby.txt", "r");
    while(1) {
        //zerowanie zmiennych       
        line_iterator = 0;        
        new_line_help.size = 0;
        new_line_help.data = malloc(sizeof(double)); //przydzielamy poczatkowo pamiec "gdzies"  

        //sprawdzenie czy nie mamy konca pliku
        c = fgetc(file);
        if(c == EOF) break;
        fseek(file, -1, SEEK_CUR); //fgetc przysuwa "kursor" w pliku, a wiec przesuwamy go o 1 o tylu      
            
        //dwie petle, 1 czyta linie, 2 czyta liczby
        while(1) { 
            //pomocnycz wektor do zapisania liczb
            new_line_help.size++;
            new_line_help.data = realloc(new_line_help.data, new_line_help.size*sizeof(double));         
             
            //czytanie slowa
            fscanf(file, "%lf", &new_line_help.data[line_iterator++]);           
            
            c = fgetc(file);   //jak wezmie spacje to sie nic nie stanie, co nam na reke         
            if(c == '\n') break;
                         
        }
        //dodanie linii do naszego glownego wektora
        v->size++;     
        v->data = realloc(v->data, v->size*sizeof(lvector));        
        v->data[vector_iterator++] = new_line_help;
    }    
}

void load_data(fvector * v) {
    //inicjalizowanie zmiennych
    FILE * file; 
    char buffer[512];
    double temporary_double;
    char * line, *offset;            
    size_t line_iterator = 0;
    size_t vector_iterator = 0;

    file = fopen("liczby.txt", "r");

    while(fgets(buffer, 512, file)) {               
        line_iterator = 0;
        v->size++;
        v->line_count = realloc(v->line_count, v->size*sizeof(lvector));

        v->line_count[vector_iterator].data = malloc(sizeof(double));
        v->line_count[vector_iterator].size = 0;
        v->line_count[vector_iterator].sum = 0;

        offset = buffer; 
        while(1 == sscanf(offset, "%lf", &temporary_double)) {
            offset = strchr(offset+1, ' '); 

            v->line_count[vector_iterator].size++;                        
            v->line_count[vector_iterator].data = realloc(v->line_count[vector_iterator].data,
            v->line_count[vector_iterator].size*sizeof(double));

            v->line_count[vector_iterator].data[line_iterator++] = temporary_double;
            v->line_count[vector_iterator].sum += temporary_double;
        }        
        vector_iterator++;
    }
}

int compare_record_order(const void *sum1, const void *sum2) {
	lvector *v_sum1 = (lvector *)sum1;
    lvector *v_sum2 = (lvector *)sum2;	
	
    if (v_sum2->sum/v_sum2->size - v_sum1->sum/v_sum1->size > 0) return 1;
    if (v_sum2->sum/v_sum2->size - v_sum1->sum/v_sum1->size < 0) return -1;
    return 0;
}

//wyswietl zawartosc
void print_data(fvector v) {
    for(int i = 0; i < v.size; ++i) {
        for(int j = 0; j < v.line_count[i].size; ++j) {
            printf("%lf ", v.line_count[i].data[j]);
        }
        printf("{%lf}\n", v.line_count[i].sum/v.line_count[i].size);
    }
}

//resetowanie wektora
void reset_vector(fvector * v) {
    //zwalnianie pamieci
    for(int i = 0; i < v->size; ++i) {
        free(v->line_count[i].data);       
    }
    free(v->line_count);

    //zerowanie rozmiaru
    v->size = 0;
}

int main(void) {
    fvector vector = initialize_f();    

    load_data(&vector);    
    print_data(vector);
    printf("\n");
    qsort(vector.line_count, vector.size, sizeof(lvector), compare_record_order);
    print_data(vector);
    reset_vector(&vector);   

    return 0;
}
