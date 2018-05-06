clc
clear
%A=[0.8978 1.6108 0 0; 0 0 0.2237 -17.695; 0 0 -2.2649 1231.1; 0 0 -0.0063 0];
%B=[ 114.35; 38.942; 0; -2.3455];
A=[0.8978-0.3416 1.6108-0.4431 0 0  ;0 0 0.2237-0.0318 -17.695-23.318 ;0 0 -2.2649-0.5876 1231.1-219.49 ;0 0 -0.0063-0.0008 0]
B=[114.35 ;38.942;0;-2.3455 ];
C=[1 0 0 0];
D=0;
Q=[100 0 0 0;0 0.01 0 0;0 0 0.01 0;0 0 0 0.01];
R=1;
K=lqr(A,B,Q,R)
k1 = K(1);
k2 = K(2); k3 = K(3); 
k4 = K(4);
AA = A - B*K;
BB = B*k1;
CC = C;
DD = D;
t = 0:0.01:50;
[y,x,t] = step (AA,BB,CC,DD,1,t);
plot(t,x(:,1))
hold all
plot(t,x(:,2))
hold all
plot(t,x(:,3))
hold all
plot(t,x(:,4))
hold all
title('Response Curves \delta u , \delta w , \delta \omega , \delta \beta versus t')
xlabel('t Sec')
ylabel('\delta u , \delta w , \delta \omega , \delta \beta')
legend('\delta u','\delta w','\delta \omega','\delta \beta')