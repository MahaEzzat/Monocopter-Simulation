clc
clear

A=[0.8978-0.3416 1.6108-0.4431 0 0  ;0 0 0.2237-0.0318 -17.695-23.318 ;0 0 -2.2649-0.5876 1231.1-219.49 ;0 0 -0.0063-0.0008 0];
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
BB = B*k4;
CC = C;
DD = D;
t = 0:0.1:1000;
[y,x,t] = step (AA,BB,CC,DD,1,t);
figure
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
syms X T
U=1/X;
e_AS =inv(X*eye(4)-AA);
Xs = e_AS*BB*U;
Xt = ilaplace(Xs, X, T);
Xt1 = real(double(subs(Xt(1),t)));
Xt2 = real(double(subs(Xt(2),t)));
Xt3 = real(double(subs(Xt(3),t)));
Xt4 = real(double(subs(Xt(4),t)));
p1 = polyfit(t,Xt1,7);
p2 = polyfit(t,Xt2,7);
p3 = polyfit(t,Xt3,7);
p4 = polyfit(t,Xt4,7);
y1 = polyval(p1,t);
y2 = polyval(p2,t);
y3 = polyval(p3,t);
y4 = polyval(p4,t);
figure
plot(t,y1)
hold on
plot(t,y2)
hold on
plot(t,y3)
hold on
plot(t,y4)
title('Fitted Response Curves \delta u , \delta w , \delta \omega , \delta \beta versus t')
xlabel('t Sec')
ylabel('\delta u , \delta w , \delta \omega , \delta \beta')
legend('\delta u','\delta w','\delta \omega','\delta \beta')