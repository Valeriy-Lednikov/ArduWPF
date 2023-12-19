void setup() {
  Serial.begin(9600); // Открыть com порт
}

int var1 = 0;
int var2 = 0;
int var3 = 0;
int var4 = 0;
int var5 = 0;

void loop() {
  var1 += 1;
  var2 += 2;
  var3 += 4;
  var4 += 8;
  var5 += 10;

  delay(5000); // Подождать 5 секунд

  // Отправить переменные в последовательный порт через ;
  Serial.print(var1);
  Serial.print(";");
  Serial.print(var2);
  Serial.print(";");
  Serial.print(var3);
  Serial.print(";");
  Serial.print(var4);
  Serial.print(";");
  Serial.println(var5);

}
