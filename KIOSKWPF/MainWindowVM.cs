using KIOSKWPF.Service.IF;
using KIOSKWPF.VM;
using Microsoft.Extensions.DependencyInjection;
using MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Converters;

namespace KIOSKWPF
{
    internal class MainWindowVM : MVVMBase
    {
        public IServiceProvider Provider { get; }

        public MainWindowVM(IServiceProvider provider)
        {
            Provider = provider;

            OrderVM = new OrderVM(provider);

            // 1. 환경 정보 로드

            // 2. 메뉴 정보 구성
            var dbService = Provider.GetRequiredService<IDBService>();
            dbService.LoadMenuData();

            // 3. 프로그램 기동
            InitOrder();
        }

        public OrderVM OrderVM { get; set; } // DI를 이용해 보도록 하자

        private void InitOrder()
        {
            OrderVM.Init();

            OrderVM.OrderComplete += OrderStepComplete;
        }

        private void OrderStepComplete(enStep step, int result)
        {
            switch(step)
            {
                case enStep.ORDER:
                    {
                        if(result == 0)
                        {
                            // 1. 메뉴 선택 완료 -> 다음 단계(장바구니)로 이동
                        }
                        else
                        {
                            // 1. 메뉴 선택 실패 또는 홈으로... -> 초기 화면(현재는 메뉴 선택)으로 이동
                        }
                    }
                    break;
                case enStep.BASKET:
                    {
                        if(result == 0)
                        {
                            // 1. 장바구니 확인 완료 -> 다음 단계(결재 수단 선택)
                        }
                        else
                        {
                            // 1. 장바구니 확인에서 취소 홈으로... -> 초기 화면(현재는 메뉴 선택)으로 이동
                        }
                    }
                    break;
                case enStep.SELECT_MEDIA:
                    {
                        if (result == 0)
                        {
                            // 1. 장바구니 확인 완료 -> 다음 단계(결재 수단 선택)
                        }
                        else
                        {
                            // 1. 장바구니 확인에서 취소 홈으로... -> 초기 화면(현재는 메뉴 선택)으로 이동
                        }
                    }
                    break;
                case enStep.EXECUTE_PAY:
                    if (result == 0)
                    {
                        // 1. 장바구니 확인 완료 -> 초기 화면(현재는 메뉴 선택)으로 이동
                    }
                    else
                    {
                        // 1. 장바구니 확인에서 취소 홈으로... -> 초기 화면(현재는 메뉴 선택)으로 이동
                    }
                    break;
                case enStep.HOME:
                    break;
            }
        }
    }
}
