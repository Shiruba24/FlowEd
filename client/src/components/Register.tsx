import React, { ChangeEvent, SyntheticEvent, useState } from "react";
import { Login, Register } from "../models/users";
import { Button, Card, Form, Input, Typography, notification } from "antd";
import { Content } from "antd/es/layout/layout";
import agent from "../actions/agent";
import { useDispatch } from "react-redux";
import { registerUser } from "../redux/slice/userSlice";
import { useAppDispatch } from "../redux/store/configureStore";

interface Props {
    toggleRegister: () => void;
}

const RegisterComponent = ({ toggleRegister }: Props) => {
    const [values, setValues] = useState<Register>({
        email: "",
        password: "",
        username: ""
    });
    const { Title, Text } = Typography;
    const { email, password, username } = values;

    const dispatch = useAppDispatch();
    const [form] = Form.useForm();
    const handleChange = (e: ChangeEvent<HTMLInputElement>) => {
        const { name, value } = e.target;
        setValues({ ...values, [name]: value });
    };

    const resetForm = () => {
        setValues({ ...values, email: "", password: "", username: "" });
        form.resetFields();
    };
    const submitUser = async (e: SyntheticEvent) => {
        e.preventDefault();

        try {
            if (email.match(/^[^\s@]+@[^\s@]+\.[^\s@]+$/) && password.length >= 6 && username.length >= 4) {
                await dispatch(registerUser(values));
            }
        } catch (error) {
            notification.error({
                message: "Please enter your credentials"
            });
            resetForm();
        }

    };

    return (
        <Card className="log-in-card">
            <div className="log-in-card__intro">
                <Typography>
                    <Title level={2} className="log-in-card__intro-title">Sign up with Learnify</Title>
                    <Text>Use your Username, Email and Password to Login!</Text>
                </Typography>
            </div>
            <Content className="log-in__form">
                <Form name="login"
                    labelCol={{ span: 8 }}
                    wrapperCol={{ span: 16 }}
                    autoComplete="off"
                    onSubmitCapture={submitUser}
                    form={form}
                >
                    <Form.Item label="Username" name="username"
                        rules={[{
                            required: true,
                            message: "Please enter a valid username!",
                            min: 4,
                            max: 25
                        }]}
                    >
                        <Input value={username} name="username" onChange={handleChange}></Input>
                    </Form.Item>


                    <Form.Item label="Email" name="email"
                        rules={[{
                            required: true,
                            message: "Please enter a valid email!",
                            pattern: /^[^\s@]+@[^\s@]+\.[^\s@]+$/
                        }]}
                    >
                        <Input value={email} name="email" onChange={handleChange}></Input>
                    </Form.Item>

                    <Form.Item label="Password" name="password"
                        rules={[{
                            required: true,
                            message: "Please enter a valid assword!",
                            min: 6,
                            max: 20
                        }]}
                    >
                        <Input.Password value={password} name="password" onChange={handleChange}></Input.Password>
                    </Form.Item>
                    <Form.Item wrapperCol={{ offset: 4, span: 16 }}>
                        <Button onClick={submitUser} type="primary" htmlType="submit">Submit</Button>
                    </Form.Item>

                </Form>
            </Content>
            <div onClick={toggleRegister} className="log-in-card__toggle">
                Already a user? Sign in
            </div>
        </Card>
    );
};




export default RegisterComponent;