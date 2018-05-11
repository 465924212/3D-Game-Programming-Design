这次作业没有完成……以下是目前想法：
在前几次的基础上，增加了两个EventManager，分别管理追逐开始与结束得分的事件。

追逐开始事件管理器中，目前想法是每帧更新时都检查一下玩家是否在巡逻兵的巡逻范围内，如果是则raise追逐开始事件。（每帧检查开销应该略大，此处应有改动）
  void Update () {
        PatrolController controller = GetComponent<PatrolController>();
    //if the character is in the controller's patrol square
        //raise event
        if (OnChaseAction != null)
        {
            controller.Patrol = false;
            OnChaseAction(this, this.name + "start chasing!");
        }
  }

追逐事件的处理者暂时定为巡逻兵本身，每个巡逻兵初始化时注册事件处理器，如果事件发生时玩家在该巡逻兵巡逻范围内，开始追逐状态。(此时需要处理如何销毁巡逻的SequenceAction)
  void Start () {
        Patrol = true;
        ChaseEventManager.OnChaseAction += StartChase;
        square = GetComponent<Transform>().position;
  }


结束得分事件管理器中，目前想法是当巡逻兵状态在追逐时，每帧更新时检查玩家是否逃出巡逻范围，如是则得分且将巡逻兵状态设置为巡逻状态。(此时需要处理如何销毁追逐的MoveToAction)
   void Update()
    {
        PatrolController controller = GetComponent<PatrolController>();
        //if the character is first in and out the controller's patrol square
        //raise event
        if (!controller.Patrol)
        {
            if (OnGetScoreAction != null)
            {
                controller.Patrol = true;
                OnGetScoreAction(this, "Get 1 point!");
            }
        }
    }


所有巡逻兵均在加载时挂载了一个SequenceAction固定巡逻路线，路线由加载时的位置决定。
    public void StartPatrol(GameObject gameObject)
    {
        Vector3 target = gameObject.transform.position;
        List<ActionBase> actions = new List<ActionBase>();
        ActionBase action = MoveToAction.GetAction(new Vector3(target.x + 2, 0, target.z), 0.2f);
        actions.Add(action);
        action = MoveToAction.GetAction(new Vector3(target.x + 2, 0, target.z + 2), 0.2f);
        actions.Add(action);
        action = MoveToAction.GetAction(new Vector3(target.x, 0, target.z + 2), 0.2f);
        actions.Add(action);
        action = MoveToAction.GetAction(new Vector3(target.x, 0, target.z), 0.2f);
        actions.Add(action);
        RunAction(gameObject, SequenceAction.GetSequenceAction(-1, 0, actions), this);
    }